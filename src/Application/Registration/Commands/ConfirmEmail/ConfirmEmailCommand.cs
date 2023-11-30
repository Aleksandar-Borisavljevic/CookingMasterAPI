using MediatR;

namespace CookingMasterApi.Application.Registration.Commands.ConfirmEmail;

public class ConfirmEmailCommand : IRequest
{
    public string Email { get; set; }
    public string Code { get; set; }

}
