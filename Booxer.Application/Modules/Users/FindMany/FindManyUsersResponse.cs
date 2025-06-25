namespace Booxer.Application.Modules.Users.FindMany;

public sealed record FindManyUsersResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Username,
    bool IsAdmin
);