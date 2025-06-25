using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Booxer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Booxer.Infrastructure.Persistence.Mappings;

public class CategoryConfiguration : BaseEntityConfiguration<Category>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        base.Configure(builder);

        builder.Property(c => c.Name)
            .HasColumnType("varchar(35)");
    }
}