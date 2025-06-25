using FluentValidation;

namespace Booxer.Application.Modules.Resources.Create;

public class CreateResourceValidator : AbstractValidator<CreateResourceRequest>
{
    public CreateResourceValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .MaximumLength(50);
    }
}