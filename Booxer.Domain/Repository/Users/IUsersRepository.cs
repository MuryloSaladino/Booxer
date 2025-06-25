using Booxer.Domain.Entities;

namespace Booxer.Domain.Repository.Users;

public interface IUsersRepository : IBaseRepository<User>
{
    Task<User> FindOneByUsernameOrEmail(string usernameOrEmail, CancellationToken cancellationToken);
}