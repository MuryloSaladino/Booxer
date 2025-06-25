using Booxer.Application.Pipeline.Authentication;
using MediatR;

namespace Booxer.Application.Modules.Reservations.Create;

[Authenticate]
public sealed record CreateReservationRequest(
    Guid ReservableId,
    DateTime StartsAt,
    DateTime EndsAt
) : IRequest<CreateReservationResponse>;