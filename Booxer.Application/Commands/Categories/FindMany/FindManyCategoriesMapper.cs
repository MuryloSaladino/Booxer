using AutoMapper;
using Booxer.Domain.Entities;

namespace Booxer.Application.Commands.Categories.FindMany;

public class FindManyCategoriesMapper : Profile
{
    public FindManyCategoriesMapper()
    {
        CreateMap<Category, FindManyCategoriesResponse>();
    }
}
