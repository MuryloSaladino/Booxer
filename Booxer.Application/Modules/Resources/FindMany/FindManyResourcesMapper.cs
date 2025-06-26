using AutoMapper;
using Booxer.Domain.Entities;

namespace Booxer.Application.Modules.Resources.FindMany;

public class FindManyResourcesMapper : Profile
{
    public FindManyResourcesMapper()
    {
        CreateMap<Resource, FindManyResourcesResponse>()
            .ForCtorParam("Category", opt => opt.MapFrom(src => src.Category.Name));
    }
}
