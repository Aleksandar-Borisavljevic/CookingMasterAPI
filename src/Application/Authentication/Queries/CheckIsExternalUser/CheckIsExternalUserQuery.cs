using CookingMasterApi.Application.Common.Interfaces;
using MediatR;

namespace CookingMasterApi.Application.Authentication.Queries.CheckIsExternalUser;

public record CheckIsExternalUserQuery : IRequest<bool>
{
}

public class CheckIsExternalUserQueryHandler : IRequestHandler<CheckIsExternalUserQuery, bool>
{
    private readonly IIdentityService _identityService;
    private readonly ICurrentUserService _currentUserService;

    public CheckIsExternalUserQueryHandler(IIdentityService identiryService, ICurrentUserService currentUserService)
    {
        _identityService = identiryService;
        _currentUserService = currentUserService;
    }

    public async Task<bool> Handle(CheckIsExternalUserQuery request, CancellationToken cancellationToken)
    {
        return await _identityService.CheckIsExternalUser(_currentUserService.Email);
    }
}
