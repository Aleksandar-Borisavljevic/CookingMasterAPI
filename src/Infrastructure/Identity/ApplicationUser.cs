using Microsoft.AspNetCore.Identity;

namespace CookingMasterApi.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public Guid? PictureUid { get; set; }
}
