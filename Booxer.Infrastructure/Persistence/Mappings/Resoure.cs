using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Booxer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Booxer.Infrastructure.Persistence.Mappings;

public class ResourceConfiguration : BaseEntityConfiguration<Resource>
{
    public override void Configure(EntityTypeBuilder<Resource> builder)
    {
        base.Configure(builder);

        builder.Property(r => r.Name)
            .HasColumnType("varchar(50)");

        builder.Property(r => r.CategoryId)
            .IsRequired();
        builder.HasOne(r => r.Category)
            .WithMany()
            .HasForeignKey(r => r.CategoryId);
        builder.Navigation(r => r.Category)
            .AutoInclude();
    }
}