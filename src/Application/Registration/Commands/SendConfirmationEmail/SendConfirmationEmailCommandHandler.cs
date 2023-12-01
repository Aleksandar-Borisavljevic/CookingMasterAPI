using MediatR;
using CookingMasterApi.Application.Common.Interfaces;


namespace CookingMasterApi.Application.Registration.Commands.SendConfirmationEmail;

public class SendConfirmationEmailCommandHandler : IRequestHandler<SendConfirmationEmailCommand>
{
    private readonly IIdentityService _identityService;
    private readonly IEmailService _emailService;

    public SendConfirmationEmailCommandHandler(IIdentityService identityService, IEmailService emailService)
    {
        _identityService = identityService;
        _emailService = emailService;
    }

    public async Task Handle(SendConfirmationEmailCommand command, CancellationToken cancellationToken)
    {

        var code = await _identityService.GetConfirmationEmailCodeAsync(command.Email);

        var user = await _identityService.GetUserInfo(command.Email);

        await _emailService.Send();
    }

}
