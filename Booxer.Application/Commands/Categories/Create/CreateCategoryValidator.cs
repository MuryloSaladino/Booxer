using FluentValidation;

namespace Booxer.Application.Commands.Categories.Create;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryRequest>
{
    public CreateCategoryValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .MaximumLength(35);
    }
}