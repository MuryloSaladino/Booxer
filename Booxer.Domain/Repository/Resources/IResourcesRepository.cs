using Booxer.Domain.Entities;

namespace Booxer.Domain.Repository.Resources;

public record ResourceFilter : BaseEntityFilter
{
    public Guid? CategoryId { get; set; }
    public string? Search { get; set; }
}

public interface IResourcesRepository : IBaseRepository<Resource, ResourceFilter>;
