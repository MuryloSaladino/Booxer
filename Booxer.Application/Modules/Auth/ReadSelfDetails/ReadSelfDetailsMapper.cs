using AutoMapper;
using Booxer.Domain.Entities;

namespace Booxer.Application.Modules.Auth.ReadSelfDetails;

public class ReadSelfDetailsMapper : Profile
{
    public ReadSelfDetailsMapper()
    {
        CreateMap<User, ReadSelfDetailsResponse>();
    }
}
