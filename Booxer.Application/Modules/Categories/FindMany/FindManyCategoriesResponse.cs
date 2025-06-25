namespace Booxer.Application.Modules.Categories.FindMany;

public sealed record FindManyCategoriesResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Name
);