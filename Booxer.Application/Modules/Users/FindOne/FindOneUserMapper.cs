using AutoMapper;
using Booxer.Domain.Entities;

namespace Booxer.Application.Modules.Users.FindOne;

public class FindOneUserMapper : Profile
{
    public FindOneUserMapper()
    {
        CreateMap<User, FindOneUserResponse>();
    }
}