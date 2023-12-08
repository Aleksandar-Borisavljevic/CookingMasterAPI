using MediatR;
using CookingMasterApi.Application.Common.Interfaces;
using CookingMasterApi.Application.File.Models;

namespace CookingMasterApi.Application.File.Images.Queries;

public class GetImageQueryHandler : IRequestHandler<GetImageQuery, FileResult>
{
    private readonly IFileService _fileService;

    public GetImageQueryHandler(IFileService fileService)
    {
        _fileService =  fileService;
    }

    public async Task<FileResult> Handle(GetImageQuery request, CancellationToken cancellationToken)
    {
        return await _fileService.ReadFile(request.ImageUid);
    }

}
