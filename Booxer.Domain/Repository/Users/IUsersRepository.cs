using Booxer.Domain.Entities;

namespace Booxer.Domain.Repository.Users;

public record UserFilter : BaseEntityFilter
{
    public string? UsernameOrEmail { get; set; }
}

public interface IUsersRepository : IBaseRepository<User, UserFilter>;
