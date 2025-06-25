using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Booxer.Domain.Entities;

namespace Booxer.Infrastructure.Persistence.Mappings;

public class UserConfiguration : BaseEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.Property(u => u.Username)
            .HasColumnType("varchar(35)")
            .IsRequired();
        builder.HasIndex(u => u.Username)
            .IsUnique();

        builder.Property(u => u.Email)
            .HasColumnType("varchar(255)")
            .IsRequired();
        builder.HasIndex(u => u.Email)
            .IsUnique();

        builder.Property(u => u.Password)
            .HasColumnType("varchar(255)")
            .IsRequired();

        builder.Property(u => u.IsAdmin)
            .HasDefaultValue(false);
    }
}