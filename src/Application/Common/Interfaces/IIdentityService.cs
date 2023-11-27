using CookingMasterApi.Application.Common.Models;

namespace CookingMasterApi.Application.Common.Interfaces;

public interface IIdentityService
{
    Task ValidateUserAsync(string userId);
    Task<UserInfo> CreateUserAsync(string email, string password);
    Task<UserInfo> CheckCredentials(string email, string password);
    Task<UserInfo> GetUserInfo(string email);
    Task<UserInfo> ExternalLoginSignInAsync();
}
