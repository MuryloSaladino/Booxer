using AutoMapper;
using Booxer.Domain.Entities;

namespace Booxer.Application.Users.Commands.Create;

public sealed class RegisterUserMapper : Profile
{
    public RegisterUserMapper()
    {
        CreateMap<CreateUserRequest, User>();
        CreateMap<User, CreateUserResponse>();
    }
}