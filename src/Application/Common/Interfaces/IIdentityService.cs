using CookingMasterApi.Application.Common.Models;
using Microsoft.AspNetCore.Authentication;

namespace CookingMasterApi.Application.Common.Interfaces;

public interface IIdentityService
{
    Task ValidateUserAsync(string userId);
    Task<string> CreateUserAsync(string email, string username, string password);
    Task<UserInfo> CheckCredentials(string usernameOrEmail, string password);
    Task<UserInfo> GetUserInfo(string usernameOrEmail);
    Task<UserInfo> ExternalLoginSignInAsync();
    AuthenticationProperties ConfigureExternalAuthenticationProperties(string provider, string redirectUrl);
}
