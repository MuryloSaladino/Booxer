namespace Booxer.Application.Auth.Commands.ReadSelfDetails;

public sealed record ReadSelfDetailsResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Username,
    string Email,
    bool IsAdmin
);