namespace Booxer.Domain.Identity;

public interface ISessionContext
{
    Guid? UserId { get; set; }
    string? AccessToken { get; set; }
    string? RefreshToken { get; set; }
    Guid GetUserIdOrThrow();
}