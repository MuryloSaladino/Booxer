using Microsoft.EntityFrameworkCore;
using Booxer.Domain.Entities;
using Booxer.Domain.Repository.RefreshTokens;
using Booxer.Infrastructure.Persistence.Context;

namespace Booxer.Infrastructure.Persistence.Repository.RefreshTokens;

public class RefreshTokensRepository(
    BooxerContext context
) : IRefreshTokensRepository
{
    public void Create(RefreshToken refreshToken)
        => context.Add(refreshToken);

    public async Task<RefreshToken> FindOneByTokenValue(string token, CancellationToken cancellationToken)
        => await context.Set<RefreshToken>()
            .Where(rt => rt.Value == token)
            .FirstOrDefaultAsync(cancellationToken)
                ?? throw new EntityNotFoundException<RefreshToken>();

    public async Task<RefreshToken> FindOneByUserId(Guid userId, CancellationToken cancellationToken)
        => await context.Set<RefreshToken>()
            .Where(rt => rt.UserId == userId)
            .FirstOrDefaultAsync(cancellationToken)
                ?? throw new EntityNotFoundException<RefreshToken>();
}
