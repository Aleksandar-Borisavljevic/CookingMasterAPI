using CookingMasterApi.Application.Common.Models;

namespace CookingMasterApi.Application.Common.Interfaces;
public interface ITokenService
{
    string GenerateAccessToken(UserInfo user);
    RefreshTokenInfo GenerateRefreshToken();
    UserInfo GetUserInfoFromAccessToken(string accessToken);
}
