using CookingMasterApi.Application.File.Models;
using MediatR;

namespace CookingMasterApi.Application.File.Images.Queries;

public class GetImageQuery : IRequest<FileResult>
{
    public Guid ImageUid { get; set; }

}
