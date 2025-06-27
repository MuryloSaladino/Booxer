using Booxer.Domain.Repository.Reservations;
using FluentValidation;

namespace Booxer.Application.Modules.Reservations.Create;

public class CreateReservationValidator : AbstractValidator<CreateReservationRequest>
{
    public CreateReservationValidator(
        IReservationsRepository reservationsRepository)
    {
        RuleFor(r => r)
            .Must(r => r.EndsAt > r.StartsAt)
            .MustAsync(async (r, cancellationToken) => !await reservationsRepository
                .ExistsInRange(r.ResourceId, (Start: r.StartsAt, End: r.EndsAt), cancellationToken));
    }
}