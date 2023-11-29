using System.Security.Claims;
using CookingMasterApi.Application.Common.Exceptions;
using CookingMasterApi.Application.Common.Interfaces;
using CookingMasterApi.Application.Common.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace CookingMasterApi.Infrastructure.Identity;

public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public IdentityService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task ValidateUserAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId); //TODO: validate is user deleted or locked or not confirmed
        if (user == null)
        {
            throw new NotFoundException("User does not exist");
        }
    }

    public async Task<UserInfo> CreateUserAsync(string email, string username, string password)
    {
        var user = new ApplicationUser
        {
            UserName = username,
            Email = email,
        };

        await _userManager.CreateAsync(user, password);

        return await GetUserInfo(username);
    }

    public async Task<UserInfo> CheckCredentials(string usernameOrEmail, string password)
    {
        var user = await _userManager.FindByNameAsync(usernameOrEmail);
        if (user is null)
        {
            user = await _userManager.FindByEmailAsync(usernameOrEmail);
        }
        if (user is null)
        {
            throw new NotFoundException("User does not exist");
        }

        var areCredentialsCorrect = await _userManager.CheckPasswordAsync(user, password);

        if (!areCredentialsCorrect)
        {
            IList<ValidationFailure> validationFailureList = new List<ValidationFailure>();

            var errorMessage = "Wrong Username/Email or Password";
            validationFailureList.Add(new ValidationFailure("", errorMessage));
            throw new ValidationException(validationFailureList);
        }

        return new UserInfo { UserId = user?.Id, Username = user?.UserName, Email = user?.Email };

    }

    public async Task<UserInfo> GetUserInfo(string usernameOrEmail)
    {
        var user = await _userManager.FindByNameAsync(usernameOrEmail);
        if (user is null)
        {
            user = await _userManager.FindByEmailAsync(usernameOrEmail);
        }
        if (user == null)
        {
            throw new NotFoundException("User does not exist");
        }

        return new UserInfo { UserId = user?.Id, Username = user?.UserName, Email = user?.Email };

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

    public AuthenticationProperties ConfigureExternalAuthenticationProperties(string provider, string redirectUrl)
    {
        return _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl); ;
    }
}
