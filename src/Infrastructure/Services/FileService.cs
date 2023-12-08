using CookingMasterApi.Application.Common.Interfaces;
using CookingMasterApi.Domain.Entities;
using CookingMasterApi.Infrastructure.Options;

namespace CookingMasterApi.Infrastructure.Services;
public class FileService: IFileService
{
    private readonly ICookingMasterDbContext _context;
    private readonly BlobStorageSettings _settings;

    public FileService(ICookingMasterDbContext context, BlobStorageSettings settings)
    {
        _context = context;
        _settings = settings;
    }

    public async Task SaveFileStream(FileDetails fileDetails, Stream fileStream)
    {
        //azure

        await _context.FileDetails.AddAsync(fileDetails);
        await _context.SaveChangesAsync(CancellationToken.None);
    }

    public async Task<Stream> ReadFileStream(Guid FileUid)
    {
        var stream = new MemoryStream();
        return stream;
    }
}
