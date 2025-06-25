namespace Booxer.Application.Modules.Users.FindOne;

public sealed record FindOneUserResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Username,
    string Email,
    bool IsAdmin
);