using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using CookingMasterApi.Application.Common.Interfaces;
using CookingMasterApi.Application.Common.Models;
using CookingMasterApi.Infrastructure.Options;
using Microsoft.IdentityModel.Tokens;

namespace CookingMasterApi.Infrastructure.Services;
public class TokenService : ITokenService
{
    private readonly JwtSettings _jwtSettings;
    private readonly RefreshTokenSettings _refreshTokenSettings;
    public TokenService(JwtSettings jwtSettings, RefreshTokenSettings refreshTokenSettings)
    {
        _jwtSettings = jwtSettings;
        _refreshTokenSettings = refreshTokenSettings;
    }

    public string GenerateAccessToken(UserInfo user) //TODO: Replace with user claims later
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserId),
             new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Email, user.Email)
        };

        var tokenGenerated = new JwtSecurityToken(_jwtSettings.Issuer, _jwtSettings.Audience,
            claims,
            expires: DateTime.UtcNow.AddHours(Convert.ToDouble(_jwtSettings.TokenExpiryHours)),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(tokenGenerated);
    }

    public RefreshTokenInfo GenerateRefreshToken()
    {
        var tokenInfo = new RefreshTokenInfo();
        tokenInfo.ExpiryDate = DateTime.UtcNow.AddDays(_refreshTokenSettings.TokenExpiryDays);
        var randomNumber = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            tokenInfo.Token = Convert.ToBase64String(randomNumber);
        }
        return tokenInfo;
    }

    public UserInfo GetUserInfoFromAccessToken(string accessToken)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            ValidAudience = _jwtSettings.Audience,
            ValidIssuer = _jwtSettings.Issuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey)),
            ValidateLifetime = false //don't care about the token's expiration date,
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken securityToken;
        var principal = tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out securityToken);
        var jwtSecurityToken = securityToken as JwtSecurityToken;
        if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals("http://www.w3.org/2001/04/xmldsig-more#hmac-sha256", StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Invalid token");

        var userInfo = new UserInfo() { UserId = principal.FindFirstValue(ClaimTypes.NameIdentifier), Username = principal.FindFirstValue(ClaimTypes.Name), Email = principal.FindFirstValue(ClaimTypes.Email) };
        return userInfo;
    }
}
