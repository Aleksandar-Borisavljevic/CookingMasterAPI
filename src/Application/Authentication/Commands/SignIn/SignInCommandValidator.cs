using FluentValidation;

namespace CookingMasterApi.Application.Authentication.Commands.SignIn;

public class SignInCommandValidator : AbstractValidator<SignInCommand>
{

    public SignInCommandValidator()
    {
        RuleFor(c => c.UsernameOrEmail)
           .NotNull()
           .NotEmpty();

        RuleFor(c => c.Password)
           .NotNull()
           .NotEmpty();

    }
}
