using AutoMapper;
using Booxer.Domain.Entities;
using Booxer.Domain.Identity;
using Booxer.Domain.Repository;
using Booxer.Domain.Repository.Reservations;
using MediatR;

namespace Booxer.Application.Commands.Reservations.Create;

public class CreateCategoryHandler(
    IReservationsRepository reservationsRepository,
    ISessionContext sessionContext,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<CreateReservationRequest, CreateReservationResponse>
{
    public async Task<CreateReservationResponse> Handle(
        CreateReservationRequest request, CancellationToken cancellationToken)
    {
        var reservation = mapper.Map<Reservation>(request);
        reservation.ReservedById = sessionContext.GetUserIdOrThrow();

        reservationsRepository.Create(reservation);
        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CreateReservationResponse>(reservation);
    }
}
