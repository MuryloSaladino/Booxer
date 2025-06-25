using FluentValidation;

namespace Booxer.Application.Modules.Reservations.Create;

public class CreateReservationValidator : AbstractValidator<CreateReservationRequest>
{
    public CreateReservationValidator()
    {
        RuleFor(r => r).Must(r => r.EndsAt > r.StartsAt);
    }
}