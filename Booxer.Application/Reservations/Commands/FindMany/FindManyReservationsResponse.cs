using Booxer.Domain.Entities;

namespace Booxer.Application.Reservations.Commands.FindMany;

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
