using Booxer.Application.Pipeline.Authentication;
using Booxer.Domain.Repository.Resources;
using MediatR;

namespace Booxer.Application.Modules.Resources.FindMany;

[Authenticate(AdminOnly = true)]
public sealed record FindManyResourcesRequest
    : ResourceFilter, IRequest<List<FindManyResourcesResponse>>;
