using MediatR;
using CookingMasterApi.Application.Common.Interfaces;


namespace CookingMasterApi.Application.Password.Commands.ForgotPassword;

public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand>
{
    private readonly IIdentityService _identityService;
    //TODO: email service;

    public ForgotPasswordCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task Handle(ForgotPasswordCommand command, CancellationToken cancellationToken)
    {

        var code = await _identityService.GetForgotPasswordCodeAsync(command.Email);

        //Mail
    }

}
