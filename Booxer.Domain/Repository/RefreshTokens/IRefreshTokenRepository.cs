using Booxer.Domain.Entities;

namespace Booxer.Domain.Repository.RefreshTokens;

public interface IRefreshTokensRepository
{
    Task<RefreshToken> FindOneOrCreate(User user, CancellationToken cancellationToken);
    Task<RefreshToken> FindOneValid(string value, CancellationToken cancellationToken);
}