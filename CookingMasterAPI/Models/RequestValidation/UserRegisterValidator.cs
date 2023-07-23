using CookingMasterAPI.Models.Request;
using FluentValidation;

namespace CookingMasterAPI.Models.RequestValidation
{
    public class UserRegisterValidator : AbstractValidator<UserRegisterRequest>
    {
        public UserRegisterValidator()
        {
            RuleFor(user => user.Username)
                .NotEmpty().WithMessage("Username is required.")
                .Length(6, 50).WithMessage("Username length must be between 6 and 50 characters.");

            RuleFor(user => user.EmailAddress)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email needs to follow a format of: example@mail.com");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password needs to have at least 6 characters")
                .Must(password => HasUpperCaseLetter(password)).WithMessage("Password needs to contain at least one capitol character.");

            RuleFor(user => user.ConfirmPassword)
                .NotEmpty().WithMessage("Passwords don't match.")
                .Equal(user => user.ConfirmPassword);
        }
        #region Custom Validation Methods
        // Check if the password contains a character that's an uppercase
        private bool HasUpperCaseLetter(string password)
        {            
            return password.Any(p => char.IsUpper(p));
        }
        #endregion
    }
}
