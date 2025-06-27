using Booxer.Application.Attributes;
using MediatR;

namespace Booxer.Application.Commands.Reservations.Create;

[Authenticate]
public sealed record CreateReservationRequest(
    Guid ResourceId,
    DateTime StartsAt,
    DateTime EndsAt
) : IRequest<CreateReservationResponse>;