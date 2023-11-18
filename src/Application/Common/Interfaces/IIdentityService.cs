using CookingMasterApi.Application.Common.Models;

namespace CookingMasterApi.Application.Common.Interfaces;

public interface IIdentityService
{
    Task ValidateUserAsync(string userId);

    Task<bool> IsInRoleAsync(string userId, string role);

    Task<bool> AuthorizeAsync(string userId, string policyName);

    Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

    Task<Result> DeleteUserAsync(string userId);
    Task<UserInfo> CheckCredentials(string username, string password);
}
