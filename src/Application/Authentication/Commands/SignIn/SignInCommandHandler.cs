using MediatR;
using CookingMasterApi.Application.Common.Interfaces;

namespace CookingMasterApi.Application.Authentication.Commands.SignIn;

public class SignInCommandHandler : IRequestHandler<SignInCommand, SignInCommandResult>
{
    private readonly IIdentityService _identityService;

    public SignInCommandHandler(IIdentityService identityService,
                                ICurrentUserService currentUserService,
                                IMediator mediator)
    {
        _identityService = identityService;
    }

    public async Task<SignInCommandResult> Handle(SignInCommand command, CancellationToken cancellationToken)
    {

        var userInfo = await _identityService.CheckCredentials(command.Email, command.Password);

        //tokenService

        return new SignInCommandResult("accessTokenTest", "refreshTokenTest");
    }

}
