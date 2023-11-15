using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CookingMasterApi.Application.Common.Interfaces;
using CookingMasterApi.Application.Common.Models;
using CookingMasterApi.Infrastructure.Options;
using Microsoft.IdentityModel.Tokens;

namespace CookingMasterApi.Infrastructure.Services;
public class TokenService : ITokenService
{
    private readonly JwtSettings _jwtSettings;
    public TokenService(JwtSettings jwtSettings)
    {
        _jwtSettings = jwtSettings;
    }

    public string GenerateAccessToken(UserInfo user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserId),
            new Claim(ClaimTypes.Email, user.Email)
        };

        var tokenGenerated = new JwtSecurityToken(_jwtSettings.Issuer, _jwtSettings.Audience,
            claims,
            expires: DateTime.Now.AddHours(Convert.ToDouble(_jwtSettings.TokenExpiryHours)),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(tokenGenerated);
    }
}
