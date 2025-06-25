using Booxer.Domain.Entities;
using Booxer.Domain.Repository.Categories;
using Booxer.Infrastructure.Persistence.Context;

namespace Booxer.Infrastructure.Persistence.Repository.Categories;

public class CategoriesRepository(
    BooxerContext context
) : BaseRepository<Category>(context), ICategoryRepository;
