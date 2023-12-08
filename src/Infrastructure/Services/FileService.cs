using System.IO;
using AutoMapper;
using Azure.Storage.Blobs;
using CookingMasterApi.Application.Common.Exceptions;
using CookingMasterApi.Application.Common.Interfaces;
using CookingMasterApi.Application.File.Models;
using CookingMasterApi.Domain.Entities;
using CookingMasterApi.Infrastructure.Options;
using Microsoft.EntityFrameworkCore;

namespace CookingMasterApi.Infrastructure.Services;
public class FileService: IFileService
{
    private readonly ICookingMasterDbContext _context;
    private readonly IMapper _mapper;
    private readonly BlobStorageSettings _settings;
    private readonly BlobServiceClient _client;

    public FileService(ICookingMasterDbContext context, IMapper mapper, BlobStorageSettings settings)
    {
        _context = context;
        _mapper = mapper;
        _settings = settings;
        _client = new BlobServiceClient(_settings.ConnectionString);
    }

    public async Task SaveFileStream(FileDetails fileDetails, Stream fileStream)
    {
        var container = _client?.GetBlobContainerClient(fileDetails.Container);
        await container?.CreateIfNotExistsAsync();

        var blob = container.GetBlobClient(fileDetails.FileUid.ToString());
        await blob.UploadAsync(fileStream);

        await _context.FileDetails.AddAsync(fileDetails);
        await _context.SaveChangesAsync(CancellationToken.None);
    }

    public async Task<FileResult> ReadFile(Guid fileUid)
    {
        var file = await _context.FileDetails.Where(x => x.FileUid == fileUid).FirstOrDefaultAsync();
        if (file is null)
        {
            throw new NotFoundException("File does not exist");
        }

        var fileResult = _mapper.Map<FileResult>(file);

        var container = _client?.GetBlobContainerClient(fileResult.Container);

        var blob = container.GetBlobClient(fileResult.FileUid.ToString());

        fileResult.File = new MemoryStream();

        using (var stream = await blob.OpenReadAsync())
        {
            await stream.CopyToAsync(fileResult.File);
            fileResult.File.Position = 0;
        }

        return fileResult;
    }
}
