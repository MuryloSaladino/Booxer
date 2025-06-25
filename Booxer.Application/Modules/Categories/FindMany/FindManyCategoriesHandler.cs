using AutoMapper;
using Booxer.Domain.Repository.Categories;
using MediatR;

namespace Booxer.Application.Modules.Categories.FindMany;

public class FindManyCategoriesHandler(
    ICategoriesRepository categoryRepository,
    IMapper mapper
) : IRequestHandler<FindManyCategoriesRequest, List<FindManyCategoriesResponse>>
{
    public async Task<List<FindManyCategoriesResponse>> Handle(
        FindManyCategoriesRequest request, CancellationToken cancellationToken)
    {
        var categories = await categoryRepository.FindMany(request, cancellationToken);

        return mapper.Map<List<FindManyCategoriesResponse>>(categories);
    }
}
