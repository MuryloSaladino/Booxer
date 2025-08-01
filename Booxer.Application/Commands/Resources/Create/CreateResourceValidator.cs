using Booxer.Domain.Repository.Categories;
using FluentValidation;

namespace Booxer.Application.Commands.Resources.Create;

public class CreateResourceValidator : AbstractValidator<CreateResourceRequest>
{
    public CreateResourceValidator(ICategoriesRepository categoriesRepository)
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(c => c.CategoryId)
            .MustAsync((id, cancellationToken) => categoriesRepository.Exists(new() { Id = id }, cancellationToken));
    }
}