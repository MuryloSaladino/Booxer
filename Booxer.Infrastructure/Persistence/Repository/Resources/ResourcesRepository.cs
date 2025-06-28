using Booxer.Domain.Entities;
using Booxer.Domain.Repository.Resources;
using Booxer.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Booxer.Infrastructure.Persistence.Repository.Resources;

public class ResourcesRepository(BooxerContext context) 
    : BaseRepository<Resource, ResourceFilter>(context), IResourcesRepository
{
    protected override IQueryable<Resource> FilterQuery(ResourceFilter filter)
    {
        var query = base.FilterQuery(filter);

        if (filter.CategoryId is Guid categoryId)
            query = query.Where(r => r.CategoryId == categoryId);

        if (filter.Search is string search)
        {
            string match = $"%{search}%";
            query = query.Where(r =>
                EF.Functions.Like(r.Category.Name, match) ||
                EF.Functions.Like(r.Name, match));
        }

        return query;
    }
}
