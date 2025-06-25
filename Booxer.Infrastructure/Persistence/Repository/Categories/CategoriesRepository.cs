using Booxer.Domain.Entities;
using Booxer.Domain.Repository.Categories;
using Booxer.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Booxer.Infrastructure.Persistence.Repository.Categories;

public class CategoriesRepository(BooxerContext context) 
    : BaseRepository<Category, CategoryFilter>(context), ICategoriesRepository
{
    protected override IQueryable<Category> FilterQuery(CategoryFilter filter)
    {
        var query = base.FilterQuery(filter);

        if (filter.MatchName is string name)
            query = query.Where(c => EF.Functions.Like(c.Name, $"%{name}%"));

        return query;
    }
}
