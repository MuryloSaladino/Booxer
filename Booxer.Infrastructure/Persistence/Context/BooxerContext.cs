using Microsoft.EntityFrameworkCore;

namespace Booxer.Infrastructure.Persistence.Context;

public class BooxerContext(DbContextOptions<BooxerContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BooxerContext).Assembly);
    }
}