namespace Booxer.Application.Commands.Resources.Create;

public sealed record CreateResourceResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    Guid CategoryId,
    string Name
);
