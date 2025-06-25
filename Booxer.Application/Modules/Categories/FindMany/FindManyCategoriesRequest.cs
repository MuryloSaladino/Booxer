using Booxer.Application.Pipeline.Authentication;
using Booxer.Domain.Repository.Categories;
using MediatR;

namespace Booxer.Application.Modules.Categories.FindMany;

[Authenticate]
public sealed record FindManyCategoriesRequest
    : CategoryFilter, IRequest<List<FindManyCategoriesResponse>>;