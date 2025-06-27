using Booxer.Application.Common.Attributes;
using Booxer.Domain.Repository.Resources;
using MediatR;

namespace Booxer.Application.Resources.Commands.FindMany;

[Authenticate(AdminOnly = true)]
public sealed record FindManyResourcesRequest
    : ResourceFilter, IRequest<List<FindManyResourcesResponse>>;
