using Booxer.Domain.Entities;
using Booxer.Domain.Repository.Resources;
using Booxer.Infrastructure.Persistence.Context;

namespace Booxer.Infrastructure.Persistence.Repository.Resources;

public class ResourcesRepository(BooxerContext context) 
    : BaseRepository<Resource, ResourceFilter>(context), IResourcesRepository
{
    protected override IQueryable<Resource> FilterQuery(ResourceFilter filter)
    {
        var query = base.FilterQuery(filter);

        if (filter.CategoryId is Guid categoryId)
            query = query.Where(r => r.CategoryId == categoryId);

        return query;
    }
}
