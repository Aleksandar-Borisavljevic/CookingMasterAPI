using CookingMasterApi.Application.Common.Interfaces;
using CookingMasterApi.Domain.Entities;
using CookingMasterApi.Infrastructure.Options;
using Microsoft.EntityFrameworkCore;

namespace CookingMasterApi.Infrastructure.Identity;

public class RefreshTokenService: IRefreshTokenService
{
    private readonly ICookingMasterDbContext _context;
    private readonly RefreshTokenSettings _refreshTokenSettings;

    public RefreshTokenService (ICookingMasterDbContext context, RefreshTokenSettings refreshTokenSettings)
    {
        _context = context;
        _refreshTokenSettings = refreshTokenSettings;
    }

    public async Task AddToken(RefreshToken refreshToken)
    {
        var tokens = await _context.RefreshTokens.Where(x => x.UserId == refreshToken.UserId).ToListAsync();
        if (tokens.Count >= _refreshTokenSettings.MaxTokenNumbers)
        {
            var first = tokens.Where(x => x.IsRevoked).FirstOrDefault();
            if (first is null)
            {
                first = tokens.FirstOrDefault();
            }
            first.Token = refreshToken.Token;
            first.ExpiryDate = refreshToken.ExpiryDate;
            first.IsRevoked = refreshToken.IsRevoked;
            await _context.SaveChangesAsync(CancellationToken.None);
            return;
        }
        await _context.RefreshTokens.AddAsync(refreshToken);
        await _context.SaveChangesAsync(CancellationToken.None);
    }

    public async Task ReplaceToken(string oldToken, RefreshToken refreshToken)
    {
        var token = await _context.RefreshTokens.Where(x => x.UserId == refreshToken.UserId && x.Token == oldToken).FirstOrDefaultAsync();
        if (token is null)
        {
            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync(CancellationToken.None);
            return;
        }
        token.Token = refreshToken.Token;
        token.ExpiryDate = refreshToken.ExpiryDate;
        token.IsRevoked = refreshToken.IsRevoked;
        await _context.SaveChangesAsync(CancellationToken.None);
        return;

    }

    public async Task<RefreshToken> GetToken(Guid userId, string refreshToken)
    {
        var result = await _context.RefreshTokens.Where(x => x.UserId == userId && x.Token == refreshToken).FirstOrDefaultAsync();

        return result;
    }

    public async Task RevokeToken(Guid userId, string refreshToken)
    {
        var result = await _context.RefreshTokens.Where(x => x.UserId == userId && x.Token == refreshToken).FirstOrDefaultAsync();
        if (result is null)
        {
            return;
        }
        result.IsRevoked = true;
        await _context.SaveChangesAsync(CancellationToken.None);
    }

}
