using MediatR;
using CookingMasterApi.Application.Common.Interfaces;
using CookingMasterApi.Domain.Entities;
using CookingMasterApi.Application.Common.Models;


namespace CookingMasterApi.Application.Registration.Commands.ConfirmEmail;

public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, AuthResult>
{
    private readonly IIdentityService _identityService;
    private readonly IRefreshTokenService _refreshTokenService;
    private readonly ITokenService _tokenService;

    public ConfirmEmailCommandHandler(IIdentityService identityService, IRefreshTokenService refreshTokenService , ITokenService tokenService)
    {
        _identityService = identityService;
        _refreshTokenService = refreshTokenService;
        _tokenService = tokenService;
    }

    public async Task<AuthResult> Handle(ConfirmEmailCommand command, CancellationToken cancellationToken)
    {

        var userInfo = await _identityService.ConfirmEmailAsync(command.Email, command.Code);

        var accessToken = _tokenService.GenerateAccessToken(userInfo);
        var refreshToken = _tokenService.GenerateRefreshToken();
        await _refreshTokenService.AddToken(new RefreshToken() { UserId = new Guid(userInfo.UserId), IsRevoked = false, Token = refreshToken.Token, ExpiryDate = refreshToken.ExpiryDate });
        return new AuthResult(userInfo.Username, accessToken, refreshToken.Token, userInfo.PictureUid);
    }

}
