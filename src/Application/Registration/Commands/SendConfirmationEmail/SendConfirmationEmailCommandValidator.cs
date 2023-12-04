using FluentValidation;


namespace CookingMasterApi.Application.Registration.Commands.SendConfirmationEmail;

public class SendConfirmationEmailCommandValidator : AbstractValidator<SendConfirmationEmailCommand>
{

    public SendConfirmationEmailCommandValidator()
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
