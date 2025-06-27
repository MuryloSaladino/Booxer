namespace Booxer.Application.Users.Commands.Create;

public sealed record CreateUserResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Username,
    string Email,
    bool IsAdmin
);