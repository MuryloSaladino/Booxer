using AutoMapper;
using Booxer.Domain.Entities;

namespace Booxer.Application.Commands.Users.FindOne;

public class FindOneUserMapper : Profile
{
    public FindOneUserMapper()
    {
        CreateMap<User, FindOneUserResponse>();
    }
}