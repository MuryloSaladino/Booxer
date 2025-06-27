using AutoMapper;
using Booxer.Domain.Entities;

namespace Booxer.Application.Auth.Commands.ReadSelfDetails;

public class ReadSelfDetailsMapper : Profile
{
    public ReadSelfDetailsMapper()
    {
        CreateMap<User, ReadSelfDetailsResponse>();
    }
}
