using Booxer.Application.Pipeline.Authentication;
using MediatR;

namespace Booxer.Application.Modules.Categories.FindMany;

[Authenticate]
public sealed record FindManyCategoriesRequest
    : IRequest<List<FindManyCategoriesResponse>>;