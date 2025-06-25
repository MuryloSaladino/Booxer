using Booxer.Application.Pipeline.Authentication;
using MediatR;

namespace Booxer.Application.Modules.Reservations.Delete;

[Authenticate]
public sealed record DeleteReservationRequest(
    Guid ReservationId
) : IRequest;