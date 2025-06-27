namespace Booxer.Application.Commands.Categories.FindMany;

public sealed record FindManyCategoriesResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Name
);