using CookingMasterApi.Application.Common.Interfaces;
using MediatR;

namespace CookingMasterApi.Application.Registration.Commands.SendConfirmationEmail;

public class SendConfirmationEmailCommand : IRequest, IContainsSensitiveData
{
    public string Email { get; set; }
    public string ReturnUrl { get; set; }

}
