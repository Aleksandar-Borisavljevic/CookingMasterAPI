﻿using CookingMasterAPI.Enums;
using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Models.Request;
using CookingMasterAPI.Models.Result;
using Microsoft.AspNetCore.Mvc;

namespace CookingMasterAPI.Services.ServiceInterfaces
{
    public interface IAuthService
    {
        Task<RegistrationResult> RegisterAsync(UserRegisterRequest request);
        Task<ActionResult<User>> LoginAsync(UserLoginRequest request);

        Task<IActionResult> VerifyAsync(string token);

        Task<IActionResult> ForgotPasswordAsync(string emailAddress);

        Task<IActionResult> ResetPasswordAsync(ResetPasswordRequest request);

    }
}
