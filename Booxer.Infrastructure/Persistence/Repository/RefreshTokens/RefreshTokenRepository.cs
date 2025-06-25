using Microsoft.EntityFrameworkCore;
using Booxer.Domain.Entities;
using Booxer.Domain.Repository.RefreshTokens;
using Booxer.Infrastructure.Persistence.Context;

namespace Booxer.Infrastructure.Persistence.Repository.RefreshTokens;

public class RefreshTokensRepository(BooxerContext context) : IRefreshTokensRepository
{
    public async Task<RefreshToken> FindOneValid(string value, CancellationToken cancellationToken)
        => await context.Set<RefreshToken>()
            .Where(rt => rt.Value == value)
            .Where(rt => rt.ExpiresAt > DateTime.UtcNow)
            .FirstOrDefaultAsync(cancellationToken)
                ?? throw new EntityNotFoundException<RefreshToken>();

    public async Task<RefreshToken> FindOneOrCreate(User user, CancellationToken cancellationToken)
    {
        var refreshToken = await context.Set<RefreshToken>()
            .Where(rt => rt.UserId == user.Id)
            .FirstOrDefaultAsync(cancellationToken);

        if (refreshToken is null)
        {
            refreshToken = RefreshToken.FromUser(user);
            context.Add(refreshToken);
        }
        return refreshToken;
    }
}
