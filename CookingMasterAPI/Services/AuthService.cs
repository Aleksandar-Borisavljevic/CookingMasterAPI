using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.Results;
using CookingMasterAPI.Data;
using CookingMasterAPI.Helpers;
using CookingMasterAPI.Models.Response;
using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Services.ServiceInterfaces;
using CookingMasterAPI.Models.Result.AuthResult;
using CookingMasterAPI.Enums.AuthStatusEnums;
using CookingMasterAPI.Models.Request.AuthRequests;

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

        public AuthService
            (
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
                        RegisterEnum.RequestIsNull,
                        RegisterEnum.RequestIsNull.GetEnumDescription()
                    );
                }
                ValidationResult result = _registerValidator.Validate(request);
                if (!result.IsValid)
                {
                    return new RegistrationResult
                    (
                        RegisterEnum.RequestIsValid,
                        String.Join('\n', result.Errors)
                    );
                }
                if (_context.Users.Any(u => u.EmailAddress == request.EmailAddress))
                {
                    return new RegistrationResult
                    (
                        RegisterEnum.MailAlreadyInUse,
                        RegisterEnum.MailAlreadyInUse.GetEnumDescription()
                    );
                }
                CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

                var user = MapRequestToUser(request, passwordHash, passwordSalt);

                user.VerificationToken = _emailGenerateService.CreateRandomToken();

                _context.Users.Add(user);

                await _context.SaveChangesAsync();

                _emailGenerateService.SendEmail(user.VerificationToken);

                return new RegistrationResult
                (
                    RegisterEnum.Success,
                    RegisterEnum.Success.GetEnumDescription()
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
                        LoginEnum.RequestIsNull,
                        LoginEnum.RequestIsNull.GetEnumDescription()
                    );
                }


                ValidationResult result = _loginValidator.Validate(request);
                if (!result.IsValid)
                {
                    return new LoginResult
                    (
                        LoginEnum.RequestIsValid,
                        String.Join('\n', result.Errors)
                    );
                }

                var user = await _context.Users.SingleOrDefaultAsync(u => u.EmailAddress == request.EmailAddress);
                if (user is null)
                {
                    return new LoginResult
                    (
                        LoginEnum.UserNotFound,
                        LoginEnum.UserNotFound.GetEnumDescription()
                    );
                }
                if (user.VerifiedAt is null)
                {
                    return new LoginResult
                    (
                        LoginEnum.UserNotVerified,
                        LoginEnum.UserNotVerified.GetEnumDescription()
                    );
                }
                if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                {
                    return new LoginResult
                    (
                        LoginEnum.InvalidPassword,
                        LoginEnum.InvalidPassword.GetEnumDescription()
                    );
                }
                var userResponse = MapUserToResponse(user);

                return new LoginResult
                (
                    LoginEnum.Success,
                    LoginEnum.Success.GetEnumDescription(),
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
                        VerifyEnum.InvalidToken,
                        VerifyEnum.InvalidToken.GetEnumDescription()
                    );
                }

                user.VerifiedAt = DateTime.Now;
                await _context.SaveChangesAsync();


                return new VerifyResult
                (
                    VerifyEnum.Success,
                    VerifyEnum.Success.GetEnumDescription()
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
                        ForgotPasswordEnum.UserNotFound,
                        ForgotPasswordEnum.UserNotFound.GetEnumDescription()
                    );
                }
                user.PasswordResetToken = _emailGenerateService.CreateRandomToken();
                user.ResetTokenExpires = DateTime.Now.AddDays(1);

                await _context.SaveChangesAsync();

                _emailGenerateService.SendEmail(user.PasswordResetToken);


                return new ForgotPasswordResult
                (
                    ForgotPasswordEnum.Success,
                    ForgotPasswordEnum.Success.GetEnumDescription()
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
                        ResetPasswordEnum.RequestIsValid,
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
                        ResetPasswordEnum.UserNotFound,
                        ResetPasswordEnum.UserNotFound.GetEnumDescription()
                    );
                }
                if (user.ResetTokenExpires < DateTime.Now)
                {
                    return new ResetPasswordResult
                    (
                        ResetPasswordEnum.ResetTokenExpired,
                        ResetPasswordEnum.ResetTokenExpired.GetEnumDescription()
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
                    ResetPasswordEnum.Success,
                    ResetPasswordEnum.Success.GetEnumDescription()
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
            var ingredients = _context.Ingredients
                .Where(ingredient => _context.UserIngredients
                .Any(ui => ui.User.UserId == user.UserId && ui.Ingredient.IngredientId == ingredient.IngredientId)).ToList();

            var ingredientResponse = MapIngredientToResponse(ingredients);
            return new UserResponse(user.Username, user.EmailAddress, ingredientResponse);
        }

        private User MapRequestToUser(UserRegisterRequest request, byte[] passwordHash, byte[] passwordSalt)
        {
            return new User
            {
                Username = request.Username,
                EmailAddress = request.EmailAddress,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
        }

        private IngredientResponse MapIngredientToResponse(Ingredient ingredient)
        {
            return new IngredientResponse
                (
                ingredient.IngredientName,
                ingredient.IconPath,
                ingredient.CreateDate,
                ingredient.DeleteDate,
                ingredient.Uid
                );
        }

        private IEnumerable<IngredientResponse> MapIngredientToResponse(IEnumerable<Ingredient> ingredients)
        {
            var ingredientsResponse = new List<IngredientResponse>();
            foreach (var item in ingredients)
            {
                ingredientsResponse.Add(MapIngredientToResponse(item));
            }
            return ingredientsResponse;
        }
    }
}
