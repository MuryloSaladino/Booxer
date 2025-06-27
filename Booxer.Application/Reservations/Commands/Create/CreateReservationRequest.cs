using Booxer.Application.Common.Attributes;
using MediatR;

namespace Booxer.Application.Reservations.Commands.Create;

[Authenticate]
public sealed record CreateReservationRequest(
    Guid ResourceId,
    DateTime StartsAt,
    DateTime EndsAt
) : IRequest<CreateReservationResponse>;