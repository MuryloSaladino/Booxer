using Booxer.Domain.Entities;

namespace Booxer.Domain.Repository.Categories;

public record CategoryFilter : BaseEntityFilter
{
    public string? MatchName { get; set; }
}

public interface ICategoriesRepository : IBaseRepository<Category, CategoryFilter>;
