using AutoMapper;
using Booxer.Domain.Entities;

namespace Booxer.Application.Users.Commands.FindMany;

public class FindManyUsersMapper : Profile
{
    public FindManyUsersMapper()
    {
        CreateMap<User, FindManyUsersResponse>();
    }
}