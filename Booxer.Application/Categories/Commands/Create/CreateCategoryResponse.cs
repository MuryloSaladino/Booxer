namespace Booxer.Application.Categories.Commands.Create;

public sealed record CreateCategoryResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Name
);
