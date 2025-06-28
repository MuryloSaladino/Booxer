using AutoMapper;
using Booxer.Domain.Entities;

namespace Booxer.Application.Commands.Resources.FindOne;

public class FindOneResourceMapper : Profile
{
    public FindOneResourceMapper()
    {
        CreateMap<Resource, FindOneResourceResponse>();
    }
}
