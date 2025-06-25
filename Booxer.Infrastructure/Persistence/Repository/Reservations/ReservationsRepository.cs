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
            .Where(r => r.StartsAt > filter.Start)
            .Where(r => r.EndsAt < filter.End);

        if (filter.CategoryId is Guid categoryId)
            query = query.Where(r => r.Resource.CategoryId == categoryId);

        return query;
    }
}
