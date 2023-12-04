using FluentValidation;


namespace CookingMasterApi.Application.Password.Commands.ForgotPassword;

public class ForgotPasswordCommandValidator : AbstractValidator<ForgotPasswordCommand>
{

    public ForgotPasswordCommandValidator()
    {
        RuleFor(c => c.Email)
           .NotNull()
           .NotEmpty()
           .EmailAddress();

        RuleFor(c => c.ReturnUrl)
          .NotNull()
          .NotEmpty();
    }
}
