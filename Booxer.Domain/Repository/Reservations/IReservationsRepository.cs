using Booxer.Domain.Entities;

namespace Booxer.Domain.Repository.Reservations;

public record ReservationFilter : BaseEntityFilter
{
    public Guid? CategoryId { get; set; }
    public Guid? ResourceId { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
}

public interface IReservationsRepository : IBaseRepository<Reservation, ReservationFilter>;
