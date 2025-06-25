using Microsoft.EntityFrameworkCore;
using Booxer.Domain.Entities;
using Booxer.Domain.Repository.Users;
using Booxer.Infrastructure.Persistence.Context;

namespace Booxer.Infrastructure.Persistence.Repository.Users;

public class UserRepository(
    BooxerContext context
) : BaseRepository<User>(context), IUsersRepository
{
    public async Task<User> FindOneByUsernameOrEmail(string usernameOrEmail, CancellationToken cancellationToken)
        => await Context.Set<User>()
            .Where(u => u.DeletedAt == null)
            .Where(u => u.Username == usernameOrEmail || u.Email == usernameOrEmail)
            .FirstOrDefaultAsync(cancellationToken)
                ?? throw new EntityNotFoundException<User>();
}