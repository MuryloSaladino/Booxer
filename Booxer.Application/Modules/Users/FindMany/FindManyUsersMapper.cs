using AutoMapper;
using Booxer.Domain.Entities;

namespace Booxer.Application.Modules.Users.FindMany;

public class FindManyUsersMapper : Profile
{
    public FindManyUsersMapper()
    {
        CreateMap<User, FindManyUsersResponse>();
    }
}