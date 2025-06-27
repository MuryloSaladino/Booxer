using AutoMapper;
using Booxer.Domain.Repository.Reservations;
using MediatR;

namespace Booxer.Application.Reservations.Commands.FindMany;

public class FindManyReservationsHandler(
    IReservationsRepository reservationsRepository,
    IMapper mapper
) : IRequestHandler<FindManyReservationsRequest, List<FindManyReservationsResponse>>
{
    public async Task<List<FindManyReservationsResponse>> Handle(
        FindManyReservationsRequest request, CancellationToken cancellationToken)
    {
        var reservations = await reservationsRepository.FindMany(request, cancellationToken);

        return mapper.Map<List<FindManyReservationsResponse>>(reservations);
    }
}
