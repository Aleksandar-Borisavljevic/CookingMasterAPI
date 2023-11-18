using MediatR;
using CookingMasterApi.Application.Common.Interfaces;
using CookingMasterApi.Domain.Entities;
using FluentValidation.Results;
using CookingMasterApi.Application.Common.Exceptions;

namespace CookingMasterApi.Application.Authentication.Commands.Refresh;

public class RefreshCommandHandler : IRequestHandler<RefreshCommand, RefreshCommandResult>
{
    private readonly IIdentityService _identityService;
    private readonly ITokenService _tokenService;
    private readonly IRefreshTokenService _refreshTokenService;

    public RefreshCommandHandler(IIdentityService identityService, ITokenService tokenService, IRefreshTokenService refreshTokenService)
    {
        _identityService = identityService;
        _tokenService = tokenService;
        _refreshTokenService = refreshTokenService;
    }

    public async Task<RefreshCommandResult> Handle(RefreshCommand command, CancellationToken cancellationToken)
    {

        var userInfo = _tokenService.GetUserInfoFromAccessToken(command.AccessToken);
        var refreshToken = await _refreshTokenService.GetToken(new Guid(userInfo.UserId), command.RefreshToken);
        await _identityService.ValidateUserAsync(userInfo.UserId);

        if (refreshToken is null || refreshToken?.ExpiryDate < DateTime.UtcNow || refreshToken?.IsRevoked == true)
        {
            IList<ValidationFailure> validationFailureList = new List<ValidationFailure>();
            var errorMessage = "Refresh token is revoked or expired";
            validationFailureList.Add(new ValidationFailure("", errorMessage));
            throw new ValidationException(validationFailureList);
        }

        var newAccessToken = _tokenService.GenerateAccessToken(userInfo);
        var newRefreshToken = _tokenService.GenerateRefreshToken();
        await _refreshTokenService.ReplaceToken(refreshToken.Token,
                                                new RefreshToken() { UserId = new Guid(userInfo.UserId), IsRevoked = false, Token = newRefreshToken.Token, ExpiryDate = refreshToken.ExpiryDate }
                                               );

        return new RefreshCommandResult(newAccessToken, newRefreshToken.Token);
    }

}
