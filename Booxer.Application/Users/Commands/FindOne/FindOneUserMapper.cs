using AutoMapper;
using Booxer.Domain.Entities;

namespace Booxer.Application.Users.Commands.FindOne;

public class FindOneUserMapper : Profile
{
    public FindOneUserMapper()
    {
        CreateMap<User, FindOneUserResponse>();
    }
}