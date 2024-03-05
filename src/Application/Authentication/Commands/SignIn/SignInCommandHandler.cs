using MediatR;
using CookingMasterApi.Application.Common.Interfaces;
using CookingMasterApi.Domain.Entities;
using CookingMasterApi.Application.Common.Models;

namespace CookingMasterApi.Application.Authentication.Commands.SignIn;

public class SignInCommandHandler : IRequestHandler<SignInCommand, AuthResult>
{
    private readonly IIdentityService _identityService;
    private readonly ITokenService _tokenService;
    private readonly IRefreshTokenService _refreshTokenService;

    public SignInCommandHandler(IIdentityService identityService, ITokenService tokenService, IRefreshTokenService refreshTokenService)
    {
        _identityService = identityService;
        _tokenService = tokenService;
        _refreshTokenService = refreshTokenService;
    }

    public async Task<AuthResult> Handle(SignInCommand command, CancellationToken cancellationToken)
    {

        var userInfo = await _identityService.CheckCredentials(command.UsernameOrEmail, command.Password);

        var accessToken = _tokenService.GenerateAccessToken(userInfo);
        var refreshToken = _tokenService.GenerateRefreshToken();
        await _refreshTokenService.AddToken(new RefreshToken() { UserId = new Guid(userInfo.UserId), IsRevoked = false, Token = refreshToken.Token, ExpiryDate = refreshToken.ExpiryDate });

        return new AuthResult(userInfo.Username, accessToken, refreshToken.Token, userInfo.PictureUid);
    }

}
