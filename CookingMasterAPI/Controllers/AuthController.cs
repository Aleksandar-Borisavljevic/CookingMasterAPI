using CookingMasterAPI.Data;
using CookingMasterAPI.Helpers;
using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Models.Request;
using CookingMasterAPI.Services.ServiceInterfaces;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Security.Cryptography;

namespace CookingMasterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region Variables
        private readonly APIDbContext _context;
        private readonly IEmailGenerateService _emailGenerateService;
        private readonly IValidator<UserRegisterRequest> _validator;
        #endregion
        public AuthController
            (
            APIDbContext context,
            IEmailGenerateService emailGenerateService,
            IValidator<UserRegisterRequest> validator
            )
        {
            _context = context;
            _emailGenerateService = emailGenerateService;
            _validator = validator;
        }

        #region PostMethods
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(UserRegisterRequest request)
        {
            try
            {
                if (request is null)
                {
                    return BadRequest(ExceptionManager.requestIsNull);
                }
                ValidationResult result = _validator.Validate(request);
                if (!result.IsValid)
                {
                    return BadRequest(String.Join('\n', result.Errors));
                }
                if (_context.Users.Any(u => u.EmailAddress == request.EmailAddress))
                {
                    return BadRequest(ExceptionManager.mailAlreadyInUse);
                }
                CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);


                var user = new User
                {
                    Username = request.Username,
                    EmailAddress = request.EmailAddress,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    VerificationToken = _emailGenerateService.CreateRandomToken()
                };

                _context.Users.Add(user);

                await _context.SaveChangesAsync();

                _emailGenerateService.SendEmail(user.VerificationToken);

                return Ok("User successfully created");
            }
            //Change this in the future
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("login")]

        public async Task<ActionResult<User>> LoginAsync(UserLoginRequest request)
        {
            try
            {
                if (request is null)
                {
                    return BadRequest(ExceptionManager.requestIsNull);
                }
                var user = await _context.Users.SingleOrDefaultAsync(u => u.EmailAddress == request.EmailAddress);
                if (user is null)
                {
                    return BadRequest(ExceptionManager.userDoesNotExist);
                }
                if (user.VerifiedAt is null)
                {
                    return BadRequest(ExceptionManager.userNotVerified);
                }
                if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                {
                    return BadRequest(ExceptionManager.invalidPassword);
                }
                return Ok(user);
            }
            //Change this in the future
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("verify")]
        public async Task<IActionResult> VerifyAsync(string token)
        {
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(u => u.VerificationToken == token);
                if (user is null)
                {
                    return BadRequest(ExceptionManager.invalidVerificationToken);
                }
                user.VerifiedAt = DateTime.Now;
                await _context.SaveChangesAsync();
                return Ok("Registration successfuly verified.");
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
                var user = await _context.Users.SingleOrDefaultAsync(u => u.EmailAddress == emailAddress);
                if (user is null)
                {
                    return BadRequest(ExceptionManager.userDoesNotExist);
                }
                user.PasswordResetToken = _emailGenerateService.CreateRandomToken();
                user.ResetTokenExpires = DateTime.Now.AddDays(1);

                await _context.SaveChangesAsync();

                _emailGenerateService.SendEmail(user.PasswordResetToken);

                return Ok("Email with password reset token has been sent to you. Please check your email.");
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
                var user = await _context.Users.SingleOrDefaultAsync(u => 
                u.EmailAddress == request.EmailAddress && 
                u.PasswordResetToken == request.ResetPasswordToken);
                if (user is null || user.ResetTokenExpires < DateTime.Now)
                {
                    return BadRequest(ExceptionManager.invalidResetPasswordToken);
                }
                CreatePasswordHash(request.NewPassword, out byte[] passwordHash, out byte[] passwordSalt);

                user.PasswordSalt = passwordSalt;
                user.PasswordHash = passwordHash;
                user.PasswordResetToken = null;
                user.ResetTokenExpires = null;

                await _context.SaveChangesAsync();

                return Ok("Password has succesfully been reset.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Methods
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
        #endregion
    }
}


