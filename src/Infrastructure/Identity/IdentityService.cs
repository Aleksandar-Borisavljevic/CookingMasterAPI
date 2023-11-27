using System.Security.Claims;
using CookingMasterApi.Application.Common.Exceptions;
using CookingMasterApi.Application.Common.Interfaces;
using CookingMasterApi.Application.Common.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using static Duende.IdentityServer.Models.IdentityResources;

namespace CookingMasterApi.Infrastructure.Identity;

public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
    private readonly IAuthorizationService _authorizationService;

    public IdentityService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
        IAuthorizationService authorizationService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
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

    public async Task<UserInfo> CreateUserAsync(string email, string password)
    {
        var user = new ApplicationUser
        {
            UserName = email,
            Email = email,
        };

        await _userManager.CreateAsync(user, password);

        return await GetUserInfo(email);
    }

    public async Task<UserInfo> CheckCredentials(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);
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

    public async Task<UserInfo> GetUserInfo(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
        {
            throw new NotFoundException("User does not exist");
        }

        return new UserInfo { UserId = user?.Id, Email = user?.Email };

    }

    public async Task<UserInfo> ExternalLoginSignInAsync()
    {
        var info = await _signInManager.GetExternalLoginInfoAsync();
        if (info is null)
        {
            IList<ValidationFailure> validationFailureList = new List<ValidationFailure>();

            var errorMessage = "Error from external provider";
            validationFailureList.Add(new ValidationFailure("", errorMessage));
            throw new ValidationException(validationFailureList);
        }
        var email = info.Principal.FindFirstValue(ClaimTypes.Email);
        var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
        if (!result.Succeeded)
        {
            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
            };
            await _userManager.CreateAsync(user);
            await _userManager.AddLoginAsync(user, info);
        }

        return await GetUserInfo(email);
    }
}
