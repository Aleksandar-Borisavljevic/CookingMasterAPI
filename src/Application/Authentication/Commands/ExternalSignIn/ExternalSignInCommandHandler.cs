using MediatR;
using CookingMasterApi.Application.Common.Interfaces;
using CookingMasterApi.Domain.Entities;

namespace CookingMasterApi.Application.Authentication.Commands.ExternalSignIn;

public class ExternalSignInCommandHandler : IRequestHandler<ExternalSignInCommand, ExternalSignInCommandResult>
{
    private readonly IIdentityService _identityService;
    private readonly ITokenService _tokenService;
    private readonly IRefreshTokenService _refreshTokenService;

    public ExternalSignInCommandHandler(IIdentityService identityService, ITokenService tokenService, IRefreshTokenService refreshTokenService)
    {
        _identityService = identityService;
        _tokenService = tokenService;
        _refreshTokenService = refreshTokenService;
    }

    public async Task<ExternalSignInCommandResult> Handle(ExternalSignInCommand command, CancellationToken cancellationToken)
    {

        var userInfo = await _identityService.ExternalLoginSignInAsync();

        var accessToken = _tokenService.GenerateAccessToken(userInfo);
        var refreshToken = _tokenService.GenerateRefreshToken();

        await _refreshTokenService.AddToken(new RefreshToken() { UserId = new Guid(userInfo.UserId), IsRevoked = false, Token = refreshToken.Token, ExpiryDate = refreshToken.ExpiryDate });

        var paramsStartSign = "?";
        if (!IsHttpUrl(command.ReturnUrl))
        {
            paramsStartSign = "#";
        }

        return new ExternalSignInCommandResult(string.Format("{0}{1}AccessToken={2}&RefreshToken={3}", command.ReturnUrl, paramsStartSign, accessToken, refreshToken));
    }

    private bool IsHttpUrl(string returnUrl)
    {
        return Uri.TryCreate(returnUrl, UriKind.Absolute, out Uri uriResult)
            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }

}
