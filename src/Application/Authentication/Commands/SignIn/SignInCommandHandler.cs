using MediatR;
using CookingMasterApi.Application.Common.Interfaces;

namespace CookingMasterApi.Application.Authentication.Commands.SignIn;

public class SignInCommandHandler : IRequestHandler<SignInCommand, SignInCommandResult>
{
    private readonly IIdentityService _identityService;
    private readonly ITokenService _tokenService;

    public SignInCommandHandler(IIdentityService identityService, ITokenService tokenService)
    {
        _identityService = identityService;
        _tokenService = tokenService;
    }

    public async Task<SignInCommandResult> Handle(SignInCommand command, CancellationToken cancellationToken)
    {

        var userInfo = await _identityService.CheckCredentials(command.Email, command.Password);

        var accessToken = _tokenService.GenerateAccessToken(userInfo);

        return new SignInCommandResult(accessToken, "refreshTokenTest");
    }

}
