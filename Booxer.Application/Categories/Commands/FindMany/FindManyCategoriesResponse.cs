namespace Booxer.Application.Categories.Commands.FindMany;

public sealed record FindManyCategoriesResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Name
);