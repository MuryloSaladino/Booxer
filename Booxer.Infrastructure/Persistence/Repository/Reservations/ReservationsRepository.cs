using Booxer.Domain.Entities;
using Booxer.Domain.Repository.Reservations;
using Booxer.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Booxer.Infrastructure.Persistence.Repository.Reservations;

public class ReservationsRepository(BooxerContext context)
    : BaseRepository<Reservation, ReservationFilter>(context), IReservationsRepository
{
    protected override IQueryable<Reservation> FilterQuery(ReservationFilter filter)
    {
        var query = base.FilterQuery(filter);

        if (filter.Start is DateTime start)
            query = query.Where(r => r.StartsAt >= start);

        if (filter.End is DateTime end)
            query = query.Where(r => r.EndsAt <= end);

        if (filter.CategoryId is Guid categoryId)
            query = query.Where(r => r.Resource.CategoryId == categoryId);

        if (filter.ResourceId is Guid resourceId)
            query = query.Where(r => r.ResourceId == resourceId);

        return query;
    }

    public Task<bool> ExistsInRange(
        Guid resourceId, (DateTime Start, DateTime End) range, CancellationToken cancellationToken)
        => Context.Set<Reservation>()
            .Where(r => r.DeletedAt == null)
            .Where(r => r.ResourceId == resourceId)
            .Where(r =>
                (r.StartsAt < range.End && r.StartsAt >= range.Start) ||
                (r.EndsAt <= range.End && r.EndsAt > range.Start)
            )
            .AnyAsync(cancellationToken);
} 
