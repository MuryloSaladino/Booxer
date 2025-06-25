using Booxer.Domain.Entities;
using Booxer.Domain.Repository.Reservations;
using Booxer.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Booxer.Infrastructure.Persistence.Repository.Reservations;

public class ReservationsRepository(
    BooxerContext context
) : BaseRepository<Reservation>(context), IReservationsRepository
{
    public Task<List<Reservation>> FindManyByDateRangeAndCategoryId(
        DateTime start, DateTime end, Guid? categoryId, CancellationToken cancellationToken
    ) => Context.Set<Reservation>()
        .Where(r => r.DeletedAt == null)
        .Where(r => categoryId == null || r.Resource.CategoryId == categoryId)
        .Where(r => r.StartsAt > start)
        .Where(r => r.EndsAt < end)
        .ToListAsync(cancellationToken);
}
