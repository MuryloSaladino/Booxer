using Booxer.Application.Attributes;
using MediatR;

namespace Booxer.Application.Commands.Reservations.Delete;

[Authenticate]
public sealed record DeleteReservationRequest(
    Guid ReservationId
) : IRequest;