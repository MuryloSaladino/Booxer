using Booxer.Domain.Entities;
using Booxer.Domain.Repository.Resources;
using Booxer.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Booxer.Infrastructure.Persistence.Repository.Resources;

public class ResourcesRepository(
    BooxerContext context
) : BaseRepository<Resource>(context), IResourcesRepository
{
    public Task<List<Resource>> FindManyByCategory(Guid? categoryId, CancellationToken cancellationToken)
        => Context.Set<Resource>()
            .Where(r => r.DeletedAt == null)
            .Where(r => categoryId == null || r.CategoryId == categoryId)
            .ToListAsync(cancellationToken);
}
