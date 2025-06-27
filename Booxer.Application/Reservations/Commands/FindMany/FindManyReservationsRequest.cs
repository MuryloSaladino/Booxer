using Booxer.Application.Common.Attributes;
using Booxer.Domain.Repository.Reservations;
using MediatR;

namespace Booxer.Application.Reservations.Commands.FindMany;

[Authenticate]
public sealed record FindManyReservationsRequest
    : ReservationFilter, IRequest<List<FindManyReservationsResponse>>;
