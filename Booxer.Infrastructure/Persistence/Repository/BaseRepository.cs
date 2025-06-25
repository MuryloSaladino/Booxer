using Microsoft.EntityFrameworkCore;
using Booxer.Domain.Common;
using Booxer.Domain.Repository;
using Booxer.Infrastructure.Persistence.Context;

namespace Booxer.Infrastructure.Persistence.Repository;

public class BaseRepository<TEntity>(
    BooxerContext context
) : IBaseRepository<TEntity> where TEntity : BaseEntity
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

    public Task<TEntity?> FindOneOrDefault(Guid id, CancellationToken cancellationToken)
        => Context.Set<TEntity>()
            .Where(entity => entity.DeletedAt == null)
            .Where(entity => entity.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<TEntity> FindOne(Guid id, CancellationToken cancellationToken)
        => await FindOneOrDefault(id, cancellationToken)
            ?? throw new EntityNotFoundException<TEntity>();

    public Task<List<TEntity>> FindMany(CancellationToken cancellationToken)
        => Context.Set<TEntity>()
            .Where(entity => entity.DeletedAt == null)
            .ToListAsync(cancellationToken);

    public Task<bool> Exists(Guid id, CancellationToken cancellationToken)
        => Context.Set<TEntity>()
            .Where(entity => entity.Id == id)
            .AnyAsync(cancellationToken);
}