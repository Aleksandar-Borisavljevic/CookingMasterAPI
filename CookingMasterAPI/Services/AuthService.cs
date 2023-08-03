using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.Results;
using CookingMasterAPI.Data;
using CookingMasterAPI.Enums;
using CookingMasterAPI.Helpers;
using CookingMasterAPI.Models.Response;
using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Models.Request;
using CookingMasterAPI.Models.Result;
using CookingMasterAPI.Services.ServiceInterfaces;

namespace CookingMasterAPI.Services
{
    public class AuthService : IAuthService
    {
        #region Variables
        private readonly APIDbContext _context;
        private readonly IEmailGenerateService _emailGenerateService;
        private readonly IValidator<UserRegisterRequest> _registerValidator;
        private readonly IValidator<UserLoginRequest> _loginValidator;
        private readonly IValidator<ResetPasswordRequest> _resetPasswordValidator;
        #endregion

        public AuthService(
            APIDbContext context,
            IEmailGenerateService emailGenerateService,
            IValidator<UserRegisterRequest> registerValidator,
            IValidator<UserLoginRequest> loginValidator,
            IValidator<ResetPasswordRequest> resetPasswordValidator
            )
        {
            _context = context;
            _emailGenerateService = emailGenerateService;
            _registerValidator = registerValidator;
            _loginValidator = loginValidator;
            _resetPasswordValidator = resetPasswordValidator;
        }

        //A brilliant example of using Tuple
        /*
        public async Task<Tuple<StatusRegisterEnum, string>> RegisterAsync(UserRegisterRequest request)
        {
            if (request is null)
            {
                return Tuple.Create(StatusRegisterEnum.RequestIsNull, StatusRegisterEnum.RequestIsNull.GetEnumDescription());
            }
            ValidationResult result = _registerValidator.Validate(request);
            if (!result.IsValid)
            {
                return Tuple.Create(StatusRegisterEnum.RequestIsValid, String.Join('\n', result.Errors));
            }
            if (_context.Users.Any(u => u.EmailAddress == request.EmailAddress))
            {
                return Tuple.Create(StatusRegisterEnum.MailAlreadyInUse, StatusRegisterEnum.MailAlreadyInUse.GetEnumDescription());
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

            return Tuple.Create(StatusRegisterEnum.Success, StatusRegisterEnum.Success.GetEnumDescription());

        }
        */

        public async Task<RegistrationResult> RegisterAsync(UserRegisterRequest request)
        {
            try
            {
                if (request is null)
                {
                    return new RegistrationResult
                    (
                        StatusRegisterEnum.RequestIsNull,
                        StatusRegisterEnum.RequestIsNull.GetEnumDescription()
                    );
                }
                ValidationResult result = _registerValidator.Validate(request);
                if (!result.IsValid)
                {
                    return new RegistrationResult
                    (
                        StatusRegisterEnum.RequestIsValid,
                        String.Join('\n', result.Errors)
                    );
                }
                if (_context.Users.Any(u => u.EmailAddress == request.EmailAddress))
                {
                    return new RegistrationResult
                    (
                        StatusRegisterEnum.MailAlreadyInUse,
                        StatusRegisterEnum.MailAlreadyInUse.GetEnumDescription()
                    );
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

                return new RegistrationResult
                (
                    StatusRegisterEnum.Success,
                    StatusRegisterEnum.Success.GetEnumDescription()
                );
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<LoginResult> LoginAsync(UserLoginRequest request)
        {
            try
            {
                if (request is null)
                {
                    return new LoginResult
                    (
                        StatusLoginEnum.RequestIsNull,
                        StatusLoginEnum.RequestIsNull.GetEnumDescription()
                    );
                }


                ValidationResult result = _loginValidator.Validate(request);
                if (!result.IsValid)
                {
                    return new LoginResult
                    (
                        StatusLoginEnum.RequestIsValid,
                        String.Join('\n', result.Errors)
                    );
                }

                var user = await _context.Users.SingleOrDefaultAsync(u => u.EmailAddress == request.EmailAddress);
                if (user is null)
                {
                    return new LoginResult
                    (
                        StatusLoginEnum.UserNotFound,
                        StatusLoginEnum.UserNotFound.GetEnumDescription()
                    );
                }
                if (user.VerifiedAt is null)
                {
                    return new LoginResult
                    (
                        StatusLoginEnum.UserNotVerified,
                        StatusLoginEnum.UserNotVerified.GetEnumDescription()
                    );
                }
                if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                {
                    return new LoginResult
                    (
                        StatusLoginEnum.InvalidPassword,
                        StatusLoginEnum.InvalidPassword.GetEnumDescription()
                    );
                }
                var userResponse = MapUserToResponse(user);

                return new LoginResult
                (
                    StatusLoginEnum.Success,
                    StatusLoginEnum.Success.GetEnumDescription(),
                    userResponse
                );
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<VerifyResult> VerifyAsync(string token)
        {
            try
            {

                var user = await _context.Users.SingleOrDefaultAsync(u => u.VerificationToken == token);
                if (user is null)
                {
                    return new VerifyResult
                    (
                        StatusVerifyEnum.InvalidToken,
                        StatusVerifyEnum.InvalidToken.GetEnumDescription()
                    );
                }
                user.VerifiedAt = DateTime.Now;
                await _context.SaveChangesAsync();


                return new VerifyResult
                (
                    StatusVerifyEnum.Success,
                    StatusVerifyEnum.Success.GetEnumDescription()
                );
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ForgotPasswordResult> ForgotPasswordAsync(string emailAddress)
        {
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(u => u.EmailAddress == emailAddress);
                if (user is null)
                {
                    return new ForgotPasswordResult
                    (
                        StatusForgotPasswordEnum.UserNotFound,
                        StatusForgotPasswordEnum.UserNotFound.GetEnumDescription()
                    );
                }
                user.PasswordResetToken = _emailGenerateService.CreateRandomToken();
                user.ResetTokenExpires = DateTime.Now.AddDays(1);

                await _context.SaveChangesAsync();

                _emailGenerateService.SendEmail(user.PasswordResetToken);


                return new ForgotPasswordResult
                (
                    StatusForgotPasswordEnum.Success,
                    StatusForgotPasswordEnum.Success.GetEnumDescription()
                );
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ResetPasswordResult> ResetPasswordAsync(ResetPasswordRequest request)
        {
            try
            {
                ValidationResult result = _resetPasswordValidator.Validate(request);
                if (!result.IsValid)
                {
                    return new ResetPasswordResult
                        (
                        StatusResetPasswordEnum.RequestIsValid,
                        String.Join('\n', result.Errors)
                        );
                }

                var user = await _context.Users.SingleOrDefaultAsync(u =>
                u.EmailAddress == request.EmailAddress &&
                u.PasswordResetToken == request.ResetPasswordToken);
                if (user is null)
                {
                    return new ResetPasswordResult
                    (
                        StatusResetPasswordEnum.UserNotFound,
                        StatusResetPasswordEnum.UserNotFound.GetEnumDescription()
                    );
                }
                if (user.ResetTokenExpires < DateTime.Now)
                {
                    return new ResetPasswordResult
                    (
                        StatusResetPasswordEnum.ResetTokenExpired,
                        StatusResetPasswordEnum.ResetTokenExpired.GetEnumDescription()
                    );
                }
                CreatePasswordHash(request.NewPassword, out byte[] passwordHash, out byte[] passwordSalt);

                user.PasswordSalt = passwordSalt;
                user.PasswordHash = passwordHash;
                user.PasswordResetToken = null;
                user.ResetTokenExpires = null;

                await _context.SaveChangesAsync();

                return new ResetPasswordResult
                (
                    StatusResetPasswordEnum.Success,
                    StatusResetPasswordEnum.Success.GetEnumDescription()
                );
            }
            catch (Exception)
            {
                throw;
            }
        }
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

        private UserResponse MapUserToResponse(User user)
        {
            return new UserResponse(user.Username, user.EmailAddress);
        }
    }
}
