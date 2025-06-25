using Booxer.Domain.Entities;

namespace Booxer.Domain.Repository.Reservations;

public interface IReservationsRepository : IBaseRepository<Reservation>
{
    Task<List<Reservation>> FindManyByDateRangeAndCategoryId(
        DateTime start, DateTime end, Guid? categoryId, CancellationToken cancellationToken);
}
