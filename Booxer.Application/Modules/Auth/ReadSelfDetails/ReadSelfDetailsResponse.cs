namespace Booxer.Application.Modules.Auth.ReadSelfDetails;

public sealed record ReadSelfDetailsResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Username,
    string Email,
    bool IsAdmin
);