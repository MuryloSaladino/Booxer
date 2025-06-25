using AutoMapper;
using Booxer.Domain.Repository.Reservations;
using MediatR;

namespace Booxer.Application.Modules.Reservations.FindMany;

public class FindManyReservationsHandler(
    IReservationsRepository reservationsRepository,
    IMapper mapper
) : IRequestHandler<FindManyReservationsRequest, List<FindManyReservationResponse>>
{
    public async Task<List<FindManyReservationResponse>> Handle(
        FindManyReservationsRequest request, CancellationToken cancellationToken)
    {
        var reservations = await reservationsRepository.FindMany(request, cancellationToken);

        return mapper.Map<List<FindManyReservationResponse>>(reservations);
    }
}
