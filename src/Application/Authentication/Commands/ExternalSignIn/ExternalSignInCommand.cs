using MediatR;
using System;

namespace CookingMasterApi.Application.Authentication.Commands.ExternalSignIn;

public class ExternalSignInCommand : IRequest<ExternalSignInCommandResult>
{
    public string Email { get; set; }
    public ExternalSignInCommand(string email)
    {
        Email = email;
    }

}
