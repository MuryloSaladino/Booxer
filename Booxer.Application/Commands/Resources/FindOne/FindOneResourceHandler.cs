using AutoMapper;
using Booxer.Domain.Repository.Resources;
using MediatR;

namespace Booxer.Application.Commands.Resources.FindOne;

public class FindOneResourceHandler(
    IResourcesRepository resourcesRepository,
    IMapper mapper
) : IRequestHandler<FindOneResourceRequest, FindOneResourceResponse>
{
    public async Task<FindOneResourceResponse> Handle(
        FindOneResourceRequest request, CancellationToken cancellationToken)
    {
        var resource = await resourcesRepository.FindOne(new()
        {
            Id = request.ResourceId
        }, cancellationToken);

        return mapper.Map<FindOneResourceResponse>(resource);
    }
}
