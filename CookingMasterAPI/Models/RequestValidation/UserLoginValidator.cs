using FluentValidation;
using CookingMasterAPI.Models.Request;

namespace CookingMasterAPI.Models.RequestValidation
{
    //TODO: create validation for User Login request 
    public class UserLoginValidator : AbstractValidator<UserLoginRequest>
    {
        public UserLoginValidator()
        {
            RuleFor(user => user.EmailAddress)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email needs to follow a format of: example@mail.com");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}
