using MediatR;
using CookingMasterApi.Application.Common.Interfaces;

namespace CookingMasterApi.Application.Authentication.Commands.Revoke;

public class RevokeCommandHandler : IRequestHandler<RevokeCommand, Unit>
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IRefreshTokenService _refreshTokenService;

    public RevokeCommandHandler(ICurrentUserService currentUserService, IRefreshTokenService refreshTokenService)
    {
        _currentUserService = currentUserService;
        _refreshTokenService = refreshTokenService;
    }

    public async Task<Unit> Handle(RevokeCommand command, CancellationToken cancellationToken)
    {

        await _refreshTokenService.RevokeToken(new Guid(_currentUserService.UserId), command.RefreshToken);
        return Unit.Value;
    }

}
