using MediatR;

namespace CookingMasterApi.Application.Registration.Commands.Register;

public class RegisterCommand : IRequest
{
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string ConfirmedPassword { get; set; }

}
