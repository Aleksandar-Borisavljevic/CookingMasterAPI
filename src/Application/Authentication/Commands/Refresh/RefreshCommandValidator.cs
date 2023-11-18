using FluentValidation;

namespace CookingMasterApi.Application.Authentication.Commands.Refresh;

public class RefreshCommandValidator : AbstractValidator<RefreshCommand>
{

    public RefreshCommandValidator()
    {
        RuleFor(c => c.AccessToken)
           .NotNull()
           .NotEmpty();

        RuleFor(c => c.RefreshToken)
           .NotNull()
           .NotEmpty();

    }
}
