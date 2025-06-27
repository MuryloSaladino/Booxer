using Booxer.Application.Common.Attributes;
using MediatR;

namespace Booxer.Application.Reservations.Commands.Delete;

[Authenticate]
public sealed record DeleteReservationRequest(
    Guid ReservationId
) : IRequest;