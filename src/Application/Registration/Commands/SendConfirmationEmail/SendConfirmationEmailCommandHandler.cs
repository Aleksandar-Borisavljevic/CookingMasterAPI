using MediatR;
using CookingMasterApi.Application.Common.Interfaces;


namespace CookingMasterApi.Application.Registration.Commands.SendConfirmationEmail;

public class SendConfirmationEmailCommandHandler : IRequestHandler<SendConfirmationEmailCommand>
{
    private readonly IIdentityService _identityService;
    //TODO: email service;

    public SendConfirmationEmailCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task Handle(SendConfirmationEmailCommand command, CancellationToken cancellationToken)
    {

        var code = await _identityService.GetConfirmationEmailCodeAsync(command.Email);

        //Mail
    }

}
