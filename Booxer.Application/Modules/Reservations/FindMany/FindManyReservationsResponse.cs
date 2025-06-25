using Booxer.Domain.Entities;

namespace Booxer.Application.Modules.Reservations.FindMany;

public sealed record FindManyReservationsResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    DateTime StartsAt,
    DateTime EndsAt,
    Resource Resource,
    string ReservedBy
);
