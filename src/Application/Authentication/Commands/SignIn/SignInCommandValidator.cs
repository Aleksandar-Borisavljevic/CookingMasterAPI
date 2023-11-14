using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookingMasterApi.Application.Authentication.Commands.SignIn;

public class SignInCommandValidator : AbstractValidator<SignInCommand>
{

    public SignInCommandValidator()
    {
        RuleFor(c => c.Email)
           .NotNull()
           .NotEmpty()
           .EmailAddress();

        RuleFor(c => c.Password)
           .NotNull()
           .NotEmpty();

    }
}
