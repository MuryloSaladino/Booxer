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
        var query = base.FilterQuery(filter)
            .Where(r => r.StartsAt > filter.Start || r.EndsAt < filter.End);

        if (filter.CategoryId is Guid categoryId)
            query = query.Where(r => r.Resource.CategoryId == categoryId);
        
        if (filter.ResourceId is Guid resourceId)
            query = query.Where(r => r.ResourceId == resourceId);

        return query;
    }
}
