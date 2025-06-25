using Booxer.Application.Pipeline.Authentication;
using Booxer.Domain.Repository.Reservations;
using MediatR;

namespace Booxer.Application.Modules.Reservations.FindMany;

[Authenticate]
public sealed record FindManyReservationsRequest
    : ReservationFilter, IRequest<List<FindManyReservationResponse>>;
