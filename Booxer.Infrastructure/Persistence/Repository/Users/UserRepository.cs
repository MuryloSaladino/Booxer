using Booxer.Domain.Entities;
using Booxer.Domain.Repository.Users;
using Booxer.Infrastructure.Persistence.Context;

namespace Booxer.Infrastructure.Persistence.Repository.Users;

public class UserRepository(BooxerContext context) 
    : BaseRepository<User, UserFilter>(context), IUsersRepository
{
    protected override IQueryable<User> FilterQuery(UserFilter filter)
    {
        var query = base.FilterQuery(filter);

        if (filter.UsernameOrEmail is string usernameOrEmail)
            query = query.Where(u => u.Username == usernameOrEmail || u.Email == usernameOrEmail);

        return query;
    }
}