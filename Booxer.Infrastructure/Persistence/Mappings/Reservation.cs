using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Booxer.Domain.Entities;

namespace Booxer.Infrastructure.Persistence.Mappings;

public class ReservationConfiguration : BaseEntityConfiguration<Reservation>
{
    public override void Configure(EntityTypeBuilder<Reservation> builder)
    {
        base.Configure(builder);

        builder.Property(r => r.StartsAt)
            .IsRequired();

        builder.Property(r => r.EndsAt)
            .IsRequired();

        builder.Property(r => r.ReservedById)
            .IsRequired();
        builder.HasOne(r => r.ReservedBy)
            .WithMany()
            .HasForeignKey(r => r.ReservedById);
        builder.Navigation(r => r.ReservedBy)
            .AutoInclude();

        builder.Property(r => r.ResourceId)
            .IsRequired();
        builder.HasOne(r => r.Resource)
            .WithMany()
            .HasForeignKey(r => r.ResourceId);
        builder.Navigation(r => r.Resource)
            .AutoInclude();
    }
}