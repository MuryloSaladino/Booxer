using Booxer.Domain.Repository.Reservations;
using FluentValidation;

namespace Booxer.Application.Commands.Reservations.Create;

public class CreateReservationValidator : AbstractValidator<CreateReservationRequest>
{
    public CreateReservationValidator(
        IReservationsRepository reservationsRepository)
    {
        RuleFor(r => r.StartsAt)
            .Must(d => d > DateTime.Now)
            .Must(d => d.Hour > 8 && d.Hour < 18);
        RuleFor(r => r.EndsAt)
            .Must(d => d.Hour > 8 && d.Hour < 18);

        RuleFor(r => r)
            .Must(r => r.EndsAt > r.StartsAt)
            .Must(r =>
            {
                var duration = r.EndsAt - r.StartsAt;
                return duration <= new TimeSpan(8, 0, 0) && duration > TimeSpan.Zero;
            })
            .MustAsync(async (r, cancellationToken) => !await reservationsRepository
                .Exists(new()
                {
                    ResourceId = r.ResourceId,
                    Start = r.StartsAt,
                    End = r.EndsAt,
                }, cancellationToken));
    }
}