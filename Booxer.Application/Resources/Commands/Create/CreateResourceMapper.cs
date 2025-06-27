using AutoMapper;
using Booxer.Domain.Entities;

namespace Booxer.Application.Resources.Commands.Create;

public sealed class RegisterResourceMapper : Profile
{
    public RegisterResourceMapper()
    {
        CreateMap<CreateResourceRequest, Resource>();
        CreateMap<Resource, CreateResourceResponse>();
    }
}