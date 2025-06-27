using Booxer.Application.Attributes;
using Booxer.Domain.Repository.Reservations;
using MediatR;

namespace Booxer.Application.Commands.Reservations.FindMany;

[Authenticate]
public sealed record FindManyReservationsRequest
    : ReservationFilter, IRequest<List<FindManyReservationsResponse>>;
