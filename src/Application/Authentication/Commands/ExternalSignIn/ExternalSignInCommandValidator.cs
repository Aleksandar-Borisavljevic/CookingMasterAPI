using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookingMasterApi.Application.Authentication.Commands.ExternalSignIn;

public class ExternalSignInCommandValidator : AbstractValidator<ExternalSignInCommand>
{

    public ExternalSignInCommandValidator()
    {
        RuleFor(c => c.Email)
           .NotNull()
           .NotEmpty()
           .EmailAddress();

    }
}
