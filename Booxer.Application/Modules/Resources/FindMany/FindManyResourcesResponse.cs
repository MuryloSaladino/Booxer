namespace Booxer.Application.Modules.Resources.FindMany;

public sealed record FindManyResourcesResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Name,
    string Category
);
