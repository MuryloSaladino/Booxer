using Booxer.Domain.Entities;

namespace Booxer.Domain.Repository.Resources;

public interface IResourcesRepository : IBaseRepository<Resource>
{
    Task<List<Resource>> FindManyByCategory(Guid? categoryId, CancellationToken cancellationToken);
}