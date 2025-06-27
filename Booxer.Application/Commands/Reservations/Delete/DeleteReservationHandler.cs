using Booxer.Domain.Repository;
using Booxer.Domain.Repository.Reservations;
using MediatR;

namespace Booxer.Application.Commands.Reservations.Delete;

public class DeleteReservationHandler(
    IReservationsRepository reservationsRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<DeleteReservationRequest>
{
    public async Task Handle(DeleteReservationRequest request, CancellationToken cancellationToken)
    {
        var reservation = await reservationsRepository.FindOne(new() { Id = request.ReservationId }, cancellationToken);

        reservationsRepository.Delete(reservation);

        await unitOfWork.Save(cancellationToken);
    }
}
