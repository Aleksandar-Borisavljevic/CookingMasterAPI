using FluentValidation;
using CookingMasterAPI.Helpers;
using CookingMasterAPI.Models.Request.AuthRequests;

namespace CookingMasterAPI.Models.RequestValidation.AuthValidation
{
    public class ResetPasswordValidator : AbstractValidator<ResetPasswordRequest>
    {
        public ResetPasswordValidator()
        {
            RuleFor(user => user.EmailAddress)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email needs to follow a format of: example@mail.com");

            RuleFor(user => user.ResetPasswordToken)
                .NotEmpty().WithMessage("Reset token is required ")
                .Length(6);

            RuleFor(user => user.NewPassword)
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
