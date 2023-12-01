﻿using MediatR;
using CookingMasterApi.Application.Common.Interfaces;


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

        await _emailService.Send();
    }

}
