using FluentValidation;


namespace CookingMasterApi.Application.Password.Commands.ChangePassword;

public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
{

    public ChangePasswordCommandValidator()
    {

        RuleFor(c => c.NewPassword)
           .NotNull()
           .NotEmpty();

        RuleFor(c => c.NewPassword)
            .Equal(x => x.ConfirmedNewPassword)
            .WithMessage("Password does not match the confirm password");

    }
}
