using Booxer.Application.Pipeline.Authentication;
using MediatR;

namespace Booxer.Application.Modules.Resources.FindMany;

[Authenticate(AdminOnly = true)]
public sealed record FindManyResourcesRequest(
    Guid? CategoryId
) : IRequest<List<FindManyResourcesResponse>>;
