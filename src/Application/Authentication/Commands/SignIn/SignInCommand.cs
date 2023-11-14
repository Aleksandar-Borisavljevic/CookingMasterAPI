using MediatR;
using System;

namespace CookingMasterApi.Application.Authentication.Commands.SignIn;

public class SignInCommand : IRequest<SignInCommandResult>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public SignInCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }

}
