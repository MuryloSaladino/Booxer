namespace Booxer.Application.Users.Commands.FindMany;

public sealed record FindManyUsersResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Username,
    bool IsAdmin
);