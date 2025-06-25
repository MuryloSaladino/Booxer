using Booxer.Domain.Identity;

namespace Booxer.Infrastructure.Identity.Context;

public class SessionContext : ISessionContext
{
    public Guid? UserId { get; set; }
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }

    public Guid GetUserIdOrThrow()
        => UserId ?? throw new InvalidSessionException();
}