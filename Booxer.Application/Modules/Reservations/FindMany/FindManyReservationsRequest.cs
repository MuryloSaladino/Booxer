using Booxer.Application.Pipeline.Authentication;
using MediatR;

namespace Booxer.Application.Modules.Reservations.FindMany;

[Authenticate]
public sealed record FindManyReservationsRequest(
    DateTime Start,
    DateTime End,
    Guid? CategoryId
) : IRequest<List<FindManyReservationResponse>>;
