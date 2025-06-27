using AutoMapper;
using Booxer.Domain.Entities;

namespace Booxer.Application.Commands.Users.FindMany;

public class FindManyUsersMapper : Profile
{
    public FindManyUsersMapper()
    {
        CreateMap<User, FindManyUsersResponse>();
    }
}