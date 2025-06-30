using Booxer.Application.Attributes;
using Booxer.Domain.Repository.Resources;
using MediatR;

namespace Booxer.Application.Commands.Resources.FindMany;

[Authenticate]
public sealed record FindManyResourcesRequest
    : ResourceFilter, IRequest<List<FindManyResourcesResponse>>;
