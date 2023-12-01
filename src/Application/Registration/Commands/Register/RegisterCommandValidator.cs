using FluentValidation;


namespace CookingMasterApi.Application.Registration.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{

    public RegisterCommandValidator()
    {
        RuleFor(c => c.Email)
           .NotNull()
           .NotEmpty()
           .EmailAddress();

        //RuleFor(c => c.Username)
        //  .NotNull()
        //  .NotEmpty();

        //RuleFor(c => c.Password)
        //   .NotNull()
        //   .NotEmpty();

        //RuleFor(c => c.Password)
        //    .Equal(x => x.ConfirmedPassword)
        //    .WithMessage("Password does not match the confirm password");

    }
}
