﻿using Microsoft.AspNetCore.Mvc;
using CookingMasterAPI.Services.ServiceInterfaces;
using CookingMasterAPI.Models.Response;
using CookingMasterAPI.Models.Result.AuthResult;
using CookingMasterAPI.Enums.AuthStatusEnums;
using CookingMasterAPI.Models.Request.AuthRequests;
using CookingMasterAPI.Data;

namespace CookingMasterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region Variables
        private readonly IAuthService _authService;
        #endregion
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }



        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(UserRegisterRequest request)
        {
            try
            {
                var result = await _authService.RegisterAsync(request);

                if (result.Status is RegisterEnum.Success)
                {
                    return Ok(result.Description);
                }

                return BadRequest(result.Description);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost("login")]
        public async Task<ActionResult<UserResponse>> LoginAsync(UserLoginRequest request)
        {
            try
            {
                var result = await _authService.LoginAsync(request);
                if (result.Status is LoginEnum.Success)
                {
                    if (result.User is null)
                    {
                        throw new ArgumentNullException(nameof(result.User), "User cannot be null.");
                    }

                    return Ok(result.User);
                }

                return BadRequest(result.Description);
            }
            //Change this in the future
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("verify")]
        public async Task<ActionResult<VerifyResult>> VerifyAsync(string token)
        {
            try
            {
                var result = await _authService.VerifyAsync(token);
                if (result.Status is VerifyEnum.Success)
                {
                    if (result.Status is VerifyEnum.InvalidToken)
                    {
                        return BadRequest(result.Description);
                    }
                }

                return Ok(result.Description);

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPasswordAsync(string emailAddress)
        {
            try
            {
                var result = await _authService.ForgotPasswordAsync(emailAddress);
                if (result.Status is ForgotPasswordEnum.Success)
                {
                    return Ok(result.Description);
                }

                return BadRequest(result.Description);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPasswordAsync(ResetPasswordRequest request)
        {
            try
            {
                var result = await _authService.ResetPasswordAsync(request);
                if (result.Status is ResetPasswordEnum.Success)
                {
                    return Ok(result.Description);
                }

                return BadRequest(result.Description);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}





