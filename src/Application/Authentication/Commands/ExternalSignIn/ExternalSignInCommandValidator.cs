using FluentValidation;

namespace CookingMasterApi.Application.Authentication.Commands.ExternalSignIn;

public class ExternalSignInCommandValidator : AbstractValidator<ExternalSignInCommand>
{

    public ExternalSignInCommandValidator()
    {
        RuleFor(c => c.ReturnUrl)
           .NotNull()
           .NotEmpty();

    }
}
