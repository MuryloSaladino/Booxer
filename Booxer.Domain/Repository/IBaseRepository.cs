using Booxer.Domain.Common;

namespace Booxer.Domain.Repository;

public record BaseEntityFilter
{
    public Guid? Id { get; set; } = null;
    public bool IncludeDeleted { get; set; } = false;
}

public interface IBaseRepository<TEntity, TFilter>
    where TEntity : BaseEntity
    where TFilter : BaseEntityFilter
{
    void Create(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task<TEntity> FindOne(TFilter filter, CancellationToken cancellationToken);
    Task<TEntity?> FindOneOrDefault(TFilter filter, CancellationToken cancellationToken);
    Task<List<TEntity>> FindMany(TFilter filter, CancellationToken cancellationToken);
    Task<bool> Exists(TFilter filter, CancellationToken cancellationToken);
}

public interface IBaseRepository<TEntity> : IBaseRepository<TEntity, BaseEntityFilter>
    where TEntity : BaseEntity;
