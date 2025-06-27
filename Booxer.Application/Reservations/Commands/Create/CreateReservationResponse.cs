namespace Booxer.Application.Reservations.Commands.Create;

public sealed record CreateReservationResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    Guid ResourceId,
    Guid ReservedById,
    DateTime StartsAt,
    DateTime EndsAt
);