using MediatR;
using System;

namespace CookingMasterApi.Application.Authentication.Commands.ExternalSignIn;

public class ExternalSignInCommand : IRequest<ExternalSignInCommandResult>
{
    public string ReturnUrl { get; set; }
    public ExternalSignInCommand(string returnUrl)
    {
        ReturnUrl = returnUrl;
    }

}
