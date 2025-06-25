using AutoMapper;
using Booxer.Domain.Entities;
using Booxer.Domain.Repository;
using Booxer.Domain.Repository.Categories;
using MediatR;

namespace Booxer.Application.Modules.Categories.Create;

public class CreateCategoryHandler(
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<CreateCategoryRequest, CreateCategoryResponse>
{
    public async Task<CreateCategoryResponse> Handle(
        CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = mapper.Map<Category>(request);

        categoryRepository.Create(category);
        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CreateCategoryResponse>(category);
    }
}
