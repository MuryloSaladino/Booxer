using Booxer.Domain.Common;

namespace Booxer.Domain.Entities;

public class Reservation : BaseEntity
{
    public required Guid ReservedById { get; set; }
    public required User ReservedBy { get; set; }

    public required Guid ResourceId { get; set; }
    public required Resource Resource { get; set; }

    public required DateTime StartsAt { get; set; }
    public required DateTime EndsAt { get; set; }
}
