using CookingMasterApi.Domain.Entities;

namespace CookingMasterApi.Application.Common.Interfaces;
public interface IRefreshTokenService
{
    Task AddToken(RefreshToken refreshToken);
    Task ReplaceToken(string oldToken, RefreshToken refreshToken);
    Task<RefreshToken> GetToken(Guid userId, string refreshToken);
    Task RevokeToken(Guid userId, string refreshToken);
}
