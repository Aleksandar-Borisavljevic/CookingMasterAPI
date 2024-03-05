using CookingMasterApi.Application.Common.Interfaces;
using CookingMasterApi.Application.Common.Models;
using MediatR;

namespace CookingMasterApi.Application.Authentication.Commands.SignIn;

public class SignInCommand : IRequest<AuthResult>, IContainsSensitiveData
{
    public string UsernameOrEmail { get; set; }
    public string Password { get; set; }
    public SignInCommand(string usernameOrEmail, string password)
    {
        UsernameOrEmail = usernameOrEmail;
        Password = password;
    }

}
