﻿using CookingMasterAPI.Models.Request;
using CookingMasterAPI.Models.Result;


namespace CookingMasterAPI.Services.ServiceInterfaces
{
    public interface IAuthService
    {
        Task<RegistrationResult> RegisterAsync(UserRegisterRequest request);
        Task<LoginResult> LoginAsync(UserLoginRequest request);

        Task<VerifyResult> VerifyAsync(string token);

        Task<ForgotPasswordResult> ForgotPasswordAsync(string emailAddress);

        Task<ResetPasswordResult> ResetPasswordAsync(ResetPasswordRequest request);

    }
}
