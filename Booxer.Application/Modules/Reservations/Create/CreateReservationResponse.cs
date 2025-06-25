namespace Booxer.Application.Modules.Reservations.Create;

public sealed record CreateReservationResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    Guid ReservableId,
    Guid ReservedById,
    DateTime StartsAt,
    DateTime EndsAt
);