namespace Booxer.Application.Resources.Commands.Create;

public sealed record CreateResourceResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    Guid CategoryId,
    string Name
);
