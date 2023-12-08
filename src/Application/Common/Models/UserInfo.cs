
namespace CookingMasterApi.Application.Common.Models;
public class UserInfo
{
    public string UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public Guid? PictureUid { get; set; }
}
