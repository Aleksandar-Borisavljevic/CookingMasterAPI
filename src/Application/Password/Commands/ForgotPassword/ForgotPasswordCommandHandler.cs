using MediatR;
using CookingMasterApi.Application.Common.Interfaces;
using CookingMasterApi.Domain.Common;
using CookingMasterApi.Application.Common.Models;

namespace CookingMasterApi.Application.Password.Commands.ForgotPassword;

public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand>
{
    private readonly IIdentityService _identityService;
    private readonly IEmailService _emailService;

    public ForgotPasswordCommandHandler(IIdentityService identityService, IEmailService emailService)
    {
        _identityService = identityService;
        _emailService = emailService;
    }

    public async Task Handle(ForgotPasswordCommand command, CancellationToken cancellationToken)
    {

        var code = await _identityService.GetForgotPasswordCodeAsync(command.Email);

        var user = await _identityService.GetUserInfo(command.Email);

        var paramsStartSign = "?";
        if (!GeneralHelper.IsHttpUrl(command.ReturnUrl))
        {
            paramsStartSign = "#";
        }

        var url = string.Format("{0}{1}Email={2}&Code={3}", command.ReturnUrl, paramsStartSign, command.Email, code);

        var emailData = new EmailData(command.Email, "Forgot Password", url);

        await _emailService.Send(emailData);
    }

}
