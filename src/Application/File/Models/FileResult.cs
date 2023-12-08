using CookingMasterApi.Application.Common.Mappings;
using CookingMasterApi.Domain.Entities;

namespace CookingMasterApi.Application.File.Models;
public class FileResult : IMapFrom<FileDetails>
{
    public Guid FileUid { get; set; }
    public string FileName { get; set; }
    public string Container { get; set; }
    public string ContentType { get; set; }
    public Stream File { get; set; }
}
