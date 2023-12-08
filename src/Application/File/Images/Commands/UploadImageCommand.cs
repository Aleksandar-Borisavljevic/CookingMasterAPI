using MediatR;
using Microsoft.AspNetCore.Http;

namespace CookingMasterApi.Application.File.Images.Commands;

public class UploadImageCommand : IRequest<Guid>
{
    public IFormFile File { get; set; }

}
