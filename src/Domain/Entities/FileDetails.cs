
namespace CookingMasterApi.Domain.Entities;
public class FileDetails
{
    public int Id { get; set; }
    public Guid FileUid { get; set; }
    public string FileName { get; set; }
    public string Container { get; set; }
    public string ContentType { get; set; }
}
