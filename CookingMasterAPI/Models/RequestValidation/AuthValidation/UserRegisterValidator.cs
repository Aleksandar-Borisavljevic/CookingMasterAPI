using FluentValidation;
using CookingMasterAPI.Helpers;
using CookingMasterAPI.Models.Request.AuthRequests;

namespace CookingMasterAPI.Models.RequestValidation.AuthValidation
{
    public class UserRegisterValidator : AbstractValidator<UserRegisterRequest>
    {
        public UserRegisterValidator()
        {
            RuleFor(user => user.Username)
                .NotEmpty().WithMessage("Username is required.")
                .Length(3, 50).WithMessage("Username length must be between 6 and 50 characters.");

            RuleFor(user => user.EmailAddress)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email needs to follow a format of: example@mail.com");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password needs to have at least 6 characters")
                .Must(ExtensionMethods.HasUpperCaseLetter).WithMessage("Password needs to contain at least one capitol character.");
            //Must(password => HasUpperCaseLetter(password))

            RuleFor(user => user.ConfirmPassword)
                .NotEmpty().WithMessage("Passwords don't match.")
                .Equal(user => user.ConfirmPassword);

        }
    }
}
