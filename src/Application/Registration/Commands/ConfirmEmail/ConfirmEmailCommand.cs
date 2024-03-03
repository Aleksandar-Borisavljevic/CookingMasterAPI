using CookingMasterApi.Application.Authentication.Commands.SignIn;
using MediatR;

namespace CookingMasterApi.Application.Registration.Commands.ConfirmEmail;

public class ConfirmEmailCommand : IRequest<SignInCommandResult>
{
    public string Email { get; set; }
    public string Code { get; set; }

}
