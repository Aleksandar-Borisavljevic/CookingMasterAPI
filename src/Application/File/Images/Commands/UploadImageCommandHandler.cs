using MediatR;
using CookingMasterApi.Application.Common.Interfaces;
using CookingMasterApi.Domain.Entities;
using CookingMasterApi.Application.Common.Constants;

namespace CookingMasterApi.Application.File.Images.Commands;

public class UploadImageCommandHandler : IRequestHandler<UploadImageCommand, Guid>
{
    private readonly IFileService _fileService;

    public UploadImageCommandHandler(IFileService fileService)
    {
        _fileService =  fileService;
    }

    public async Task<Guid> Handle(UploadImageCommand command, CancellationToken cancellationToken)
    {
        var fileDetails = new FileDetails { FileUid = Guid.NewGuid(), Container = BlobContainers.Images, ContentType = command.File.ContentType, FileName = command.File.FileName };
        await _fileService.SaveFileStream(fileDetails, command.File.OpenReadStream());
        return fileDetails.FileUid;
    }

}
