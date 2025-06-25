using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Booxer.Domain.Entities;

namespace Booxer.Infrastructure.Persistence.Mappings;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.HasKey(rt => rt.UserId);
        builder.Property(rt => rt.UserId)
            .IsRequired();

        builder.HasOne(rt => rt.User)
            .WithOne()
            .HasForeignKey<RefreshToken>(rt => rt.UserId);
        builder.Navigation(rt => rt.User)
            .AutoInclude();

        builder.Property(rt => rt.RevokedAt)
            .IsRequired();

        builder.Property(rt => rt.ExpiresAt)
            .IsRequired();

        builder.Property(rt => rt.Value)
            .HasColumnType("varchar(50)")
            .IsRequired();
    }
}