using Booxer.Domain.Entities;

namespace Booxer.Application.Commands.Resources.FindOne;

public sealed record FindOneResourceResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Name,
    Category Category
);