using Booxer.Domain.Entities;

namespace Booxer.Domain.Identity;

public class TokenPayload
{
    public required Guid UserId { get; init; }
    public required string Username { get; init; }
    public required string Email { get; init; }
    public required bool IsAdmin { get; init; }

    public static TokenPayload FromUser(User user) => new()
    {
        UserId = user.Id,
        IsAdmin = user.IsAdmin,
        Username = user.Username,
        Email = user.Email,
    };
}

public interface ITokenAuthenticator
{
    string GenerateToken(TokenPayload props);
    TokenPayload Extract(string token);
}