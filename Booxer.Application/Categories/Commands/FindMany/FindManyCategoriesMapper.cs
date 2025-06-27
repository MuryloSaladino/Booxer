using AutoMapper;
using Booxer.Domain.Entities;

namespace Booxer.Application.Categories.Commands.FindMany;

public class FindManyCategoriesMapper : Profile
{
    public FindManyCategoriesMapper()
    {
        CreateMap<Category, FindManyCategoriesResponse>();
    }
}
