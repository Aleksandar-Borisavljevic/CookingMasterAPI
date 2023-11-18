using CookingMasterApi.Application.Common.Exceptions;
using CookingMasterApi.Application.Common.Interfaces;
using CookingMasterApi.Application.Common.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CookingMasterApi.Infrastructure.Identity;

public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
    private readonly IAuthorizationService _authorizationService;

    public IdentityService(
        UserManager<ApplicationUser> userManager,
        IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
        IAuthorizationService authorizationService)
    {
        _userManager = userManager;
        _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        _authorizationService = authorizationService;
    }

    public async Task ValidateUserAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId); //TODO: validate is user deleted or locked or not confirmed
        if (user == null)
        {
            throw new NotFoundException("User does not exist");
        }
    }

    public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
    {
        var user = new ApplicationUser
        {
            UserName = userName,
            Email = userName,
        };

        var result = await _userManager.CreateAsync(user, password);

        return (result.ToApplicationResult(), user.Id);
    }

    public async Task<bool> IsInRoleAsync(string userId, string role)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null && await _userManager.IsInRoleAsync(user, role);
    }

    public async Task<bool> AuthorizeAsync(string userId, string policyName)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        if (user == null)
        {
            return false;
        }

        var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

        var result = await _authorizationService.AuthorizeAsync(principal, policyName);

        return result.Succeeded;
    }

    public async Task<Result> DeleteUserAsync(string userId)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null ? await DeleteUserAsync(user) : Result.Success();
    }

    public async Task<Result> DeleteUserAsync(ApplicationUser user)
    {
        var result = await _userManager.DeleteAsync(user);

        return result.ToApplicationResult();
    }

    public async Task<UserInfo> CheckCredentials(string username, string password)
    {
        var user = await _userManager.FindByEmailAsync(username);
        if (user == null)
        {
            throw new NotFoundException("User does not exist");
        }

        var areCredentialsCorrect = await _userManager.CheckPasswordAsync(user, password);

        if (!areCredentialsCorrect)
        {
            IList<ValidationFailure> validationFailureList = new List<ValidationFailure>();

            var errorMessage = "Wrong Email or Password";
            validationFailureList.Add(new ValidationFailure("", errorMessage));
            throw new ValidationException(validationFailureList);
        }

        return new UserInfo { UserId = user?.Id, Email = user?.Email };

    }
}
