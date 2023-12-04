using MediatR;
using CookingMasterApi.Application.Common.Interfaces;
using CookingMasterApi.Domain.Entities;
using CookingMasterApi.Domain.Common;

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

        var paramsStartSign = "?";
        if (!GeneralHelper.IsHttpUrl(command.ReturnUrl))
        {
            paramsStartSign = "#";
        }

       var url = string.Format("{0}{1}Email={2}&Code={3}", command.ReturnUrl, paramsStartSign, command.Email, code);

        await _emailService.Send();
    }

}
