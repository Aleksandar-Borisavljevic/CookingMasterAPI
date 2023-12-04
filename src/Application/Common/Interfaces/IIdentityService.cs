﻿using CookingMasterApi.Application.Common.Models;
using Microsoft.AspNetCore.Authentication;

namespace CookingMasterApi.Application.Common.Interfaces;

public interface IIdentityService
{
    Task ValidateUserByIdAsync(string userId);
    Task<string> GetForgotPasswordCodeAsync(string email);
    Task<string> GetConfirmationEmailCodeAsync(string email);
    Task CreateUserAsync(string email, string username, string password);
    Task<UserInfo> CheckCredentials(string usernameOrEmail, string password);
    Task<UserInfo> GetUserInfo(string usernameOrEmail);
    Task<UserInfo> ExternalLoginSignInAsync();
    AuthenticationProperties ConfigureExternalAuthenticationProperties(string provider, string redirectUrl);
    Task ConfirmEmailAsync(string email, string code);
    Task<UserInfo> ResetPasswordAsync(string email, string code, string password);
    Task ChangePasswordAsync(string username, string oldPassword, string newPassword);
    Task<bool> CheckIsExternalUser(string email);
    Task<bool> IsEmailConfirmationCodeValid(string email, string code);
    Task<bool> IsResetPasswordCodeValid(string email, string code);
}
