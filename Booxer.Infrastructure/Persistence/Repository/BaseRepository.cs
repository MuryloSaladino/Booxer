using Booxer.Domain.Common;
using Booxer.Domain.Repository;
using Booxer.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Booxer.Infrastructure.Persistence.Repository;

public class BaseRepository<TEntity, TFilter>(
    BooxerContext context
) : IBaseRepository<TEntity, TFilter> 
    where TEntity : BaseEntity
    where TFilter : BaseEntityFilter
{
    protected BooxerContext Context = context;

    public void Create(TEntity entity)
    {
        Context.Add(entity);
    }

    public void Update(TEntity entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        Context.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        entity.DeletedAt = DateTime.UtcNow;
        Context.Update(entity);
    }

    protected virtual IQueryable<TEntity> FilterQuery(TFilter filter)
    {
        var query = Context.Set<TEntity>().AsQueryable();

        if (filter.Id is Guid id)
            query = query.Where(e => e.Id == id);

        if (!filter.IncludeDeleted)
            query = query.Where(e => e.DeletedAt == null);

        return query;
    }

    public Task<TEntity?> FindOneOrDefault(TFilter filter, CancellationToken cancellationToken)
        => FilterQuery(filter).FirstOrDefaultAsync(cancellationToken);

    public async Task<TEntity> FindOne(TFilter filter, CancellationToken cancellationToken)
        => await FindOneOrDefault(filter, cancellationToken) ?? throw new EntityNotFoundException<TEntity>();

    public Task<List<TEntity>> FindMany(TFilter filter, CancellationToken cancellationToken)
        => FilterQuery(filter).ToListAsync(cancellationToken);

    public Task<bool> Exists(TFilter filter, CancellationToken cancellationToken)
        => FilterQuery(filter).AnyAsync(cancellationToken);
}
