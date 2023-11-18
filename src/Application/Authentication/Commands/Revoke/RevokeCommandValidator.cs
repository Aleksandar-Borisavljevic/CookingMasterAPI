using FluentValidation;

namespace CookingMasterApi.Application.Authentication.Commands.Revoke;

public class RevokeCommandValidator : AbstractValidator<RevokeCommand>
{

    public RevokeCommandValidator()
    {
        RuleFor(c => c.RefreshToken)
           .NotNull()
           .NotEmpty();

    }
}
