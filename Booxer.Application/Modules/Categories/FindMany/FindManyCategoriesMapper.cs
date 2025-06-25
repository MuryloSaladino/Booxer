using AutoMapper;
using Booxer.Domain.Entities;

namespace Booxer.Application.Modules.Categories.FindMany;

public class FindManyCategoriesMapper : Profile
{
    public FindManyCategoriesMapper()
    {
        CreateMap<Category, FindManyCategoriesResponse>();
    }
}
