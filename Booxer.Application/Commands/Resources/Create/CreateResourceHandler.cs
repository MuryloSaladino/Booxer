using AutoMapper;
using Booxer.Domain.Entities;
using Booxer.Domain.Repository;
using Booxer.Domain.Repository.Resources;
using MediatR;

namespace Booxer.Application.Commands.Resources.Create;

public class CreateResourceHandler(
    IResourcesRepository resourcesRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<CreateResourceRequest, CreateResourceResponse>
{
    public async Task<CreateResourceResponse> Handle(
        CreateResourceRequest request, CancellationToken cancellationToken)
    {
        var resource = mapper.Map<Resource>(request);

        resourcesRepository.Create(resource);
        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CreateResourceResponse>(resource);
    }
}
