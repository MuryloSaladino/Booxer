using AutoMapper;
using Booxer.Domain.Repository.Resources;
using MediatR;

namespace Booxer.Application.Modules.Resources.FindMany;

public class FindManyResourcesHandler(
    IResourcesRepository resourcesRepository,
    IMapper mapper
) : IRequestHandler<FindManyResourcesRequest, List<FindManyResourcesResponse>>
{
    public async Task<List<FindManyResourcesResponse>> Handle(
        FindManyResourcesRequest request, CancellationToken cancellationToken)
    {
        var resources = await resourcesRepository.FindMany(request, cancellationToken);

        return mapper.Map<List<FindManyResourcesResponse>>(resources);
    }
}
