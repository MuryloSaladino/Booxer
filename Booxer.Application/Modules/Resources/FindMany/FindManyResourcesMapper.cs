using AutoMapper;
using Booxer.Domain.Entities;

namespace Booxer.Application.Modules.Resources.FindMany;

public class FindManyReservablesMapper : Profile
{
    public FindManyReservablesMapper()
    {
        CreateMap<Resource, FindManyResourcesResponse>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name));
    }
}
