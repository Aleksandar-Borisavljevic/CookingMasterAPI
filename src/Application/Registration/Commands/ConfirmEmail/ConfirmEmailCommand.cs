using CookingMasterApi.Application.Common.Models;
using MediatR;

namespace CookingMasterApi.Application.Registration.Commands.ConfirmEmail;

public class ConfirmEmailCommand : IRequest<AuthResult>
{
    public string Email { get; set; }
    public string Code { get; set; }

}
