using FluentValidation;

namespace CookingMasterApi.Application.Password.Commands.ResetPassword;

public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
{

    public ResetPasswordCommandValidator()
    {
        RuleFor(c => c.Email)
           .NotNull()
           .NotEmpty()
           .EmailAddress();

        RuleFor(c => c.Code)
          .NotNull()
          .NotEmpty();

        RuleFor(c => c.Password)
           .NotNull()
           .NotEmpty();

        RuleFor(c => c.Password)
           .Equal(x => x.ConfirmedPassword)
           .WithMessage("Password does not match the confirm password");

    }
}
