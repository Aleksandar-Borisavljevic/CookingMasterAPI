using MediatR;
using System;

namespace CookingMasterApi.Application.Authentication.Commands.SignIn;

public class SignInCommand : IRequest<SignInCommandResult>
{
    public string UsernameOrEmail { get; set; }
    public string Password { get; set; }
    public SignInCommand(string usernameOrEmail, string password)
    {
        UsernameOrEmail = usernameOrEmail;
        Password = password;
    }

}
