using System.Security.Claims;
using CookingMasterApi.Application.Common.Exceptions;
using CookingMasterApi.Application.Common.Interfaces;
using CookingMasterApi.Application.Common.Models;
using FluentValidation.Results;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using static Duende.IdentityServer.Models.IdentityResources;

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

    public async Task ValidateUserByIdAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user is null)
        {
            throw new NotFoundException("User does not exist");
        }

        var isEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);

        if (!isEmailConfirmed)
        {
            throw new ValidationException(string.Empty, "Email Not Confirmed");
        }
    }

    public async Task<string> GetForgotPasswordCodeAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user is null)
        {
            throw new NotFoundException("User with this email does not exist");
        }

        return await _userManager.GeneratePasswordResetTokenAsync(user);
    }

    public async Task<string> GetConfirmationEmailCodeAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user is null)
        {
            throw new NotFoundException("User with this email does not exist");
        }
        var isEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);

        if (isEmailConfirmed)
        {
            throw new ValidationException(string.Empty, "Email is Already Confirmed");
        }

        return await _userManager.GenerateEmailConfirmationTokenAsync(user);

    }

    public async Task CreateUserAsync(string email, string username, string password)
    {
        var user = new ApplicationUser
        {
            UserName = username,
            Email = email,
        };

        await CreateApplicationUser(user, password);
    }

    public async Task<UserInfo> CheckCredentials(string usernameOrEmail, string password)
    {
        var user = await GetApplicationUser(usernameOrEmail);

        var areCredentialsCorrect = await _userManager.CheckPasswordAsync(user, password);

        if (!areCredentialsCorrect)
        {
            throw new ValidationException(string.Empty, "Wrong Password");
        }

        var isEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);

        if (!isEmailConfirmed)
        {
            throw new ValidationException(string.Empty, "Email Not Confirmed");
        }

        return new UserInfo { UserId = user?.Id, Username = user?.UserName, Email = user?.Email };

    }

    public async Task<UserInfo> GetUserInfo(string usernameOrEmail)
    {
        var user = await GetApplicationUser(usernameOrEmail);

        return new UserInfo { UserId = user?.Id, Username = user?.UserName, Email = user?.Email };

    }

    public async Task<UserInfo> ExternalLoginSignInAsync()
    {
        var info = await _signInManager.GetExternalLoginInfoAsync();

        if (info is null)
        {
            throw new ValidationException(string.Empty, "Error from external provider");
        }

        var email = info.Principal.FindFirstValue(ClaimTypes.Email);
        var picture = info.Principal.FindFirstValue(JwtClaimTypes.Picture);
        var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

        if (!result.Succeeded)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null)
            {
                user = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                };

                await CreateApplicationUser(user);

                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                await _userManager.ConfirmEmailAsync(user, code);
            }

            await _userManager.AddLoginAsync(user, info);
        }

        return await GetUserInfo(email);
    }

    public AuthenticationProperties ConfigureExternalAuthenticationProperties(string provider, string redirectUrl)
    {
        return _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl); ;
    }

    public async Task ConfirmEmailAsync(string email, string code)
    {
        var user = await GetApplicationUser(email);

        var result = await _userManager.ConfirmEmailAsync(user, code);

        if (!result.Succeeded && result.Errors.Any())
        {
            IList<ValidationFailure> validationFailureList = new List<ValidationFailure>();
            foreach (var error in result.Errors)
            {
                validationFailureList.Add(new ValidationFailure(string.Empty, error.Description));
            }
            throw new ValidationException(validationFailureList);
        }
    }

    public async Task<UserInfo> ResetPasswordAsync(string email, string code, string password)
    {
        var user = await GetApplicationUser(email);

        var result = await _userManager.ResetPasswordAsync(user, code, password);

        if (!result.Succeeded && result.Errors.Any())
        {
            IList<ValidationFailure> validationFailureList = new List<ValidationFailure>();
            foreach (var error in result.Errors)
            {
                validationFailureList.Add(new ValidationFailure(string.Empty, error.Description));
            }
            throw new ValidationException(validationFailureList);
        }

        return new UserInfo { UserId = user?.Id, Username = user?.UserName, Email = user?.Email };
    }

    public async Task ChangePasswordAsync(string username, string oldPassword, string newPassword)
    {
        var user = await GetApplicationUser(username);

        var externalLogins = await _userManager.GetLoginsAsync(user);

        IdentityResult result;

        if (externalLogins.Any())
        {
            result = await _userManager.AddPasswordAsync(user, newPassword);
        }
        else
        {
            result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        }

        if (!result.Succeeded && result.Errors.Any())
        {
            IList<ValidationFailure> validationFailureList = new List<ValidationFailure>();
            foreach (var error in result.Errors)
            {
                validationFailureList.Add(new ValidationFailure(string.Empty, error.Description));
            }
            throw new ValidationException(validationFailureList);
        }
    }

    public async Task<bool> CheckIsExternalUser(string email)
    {
        var user = await GetApplicationUser(email);

        var externalLogins = await _userManager.GetLoginsAsync(user);

        return externalLogins.Any();
    }

    private async Task<ApplicationUser> GetApplicationUser(string usernameOrEmail)
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

        return user;
    }

    private async Task CreateApplicationUser(ApplicationUser user, string password = null)
    {
        var result = string.IsNullOrEmpty(password) ? await _userManager.CreateAsync(user) : await _userManager.CreateAsync(user, password);
        if (!result.Succeeded && result.Errors.Any())
        {
            IList<ValidationFailure> validationFailureList = new List<ValidationFailure>();
            foreach (var error in result.Errors)
            {
                validationFailureList.Add(new ValidationFailure(string.Empty, error.Description));
            }
            throw new ValidationException(validationFailureList);
        }
    }
}
