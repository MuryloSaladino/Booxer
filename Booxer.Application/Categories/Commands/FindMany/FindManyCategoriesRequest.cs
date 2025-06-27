using Booxer.Application.Common.Attributes;
using Booxer.Domain.Repository.Categories;
using MediatR;

namespace Booxer.Application.Categories.Commands.FindMany;

[Authenticate]
public sealed record FindManyCategoriesRequest
    : CategoryFilter, IRequest<List<FindManyCategoriesResponse>>;