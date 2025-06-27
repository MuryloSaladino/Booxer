using Booxer.Application.Attributes;
using Booxer.Domain.Repository.Categories;
using MediatR;

namespace Booxer.Application.Commands.Categories.FindMany;

[Authenticate]
public sealed record FindManyCategoriesRequest
    : CategoryFilter, IRequest<List<FindManyCategoriesResponse>>;