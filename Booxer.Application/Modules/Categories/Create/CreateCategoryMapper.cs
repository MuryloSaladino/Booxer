using AutoMapper;
using Booxer.Domain.Entities;

namespace Booxer.Application.Modules.Categories.Create;

public sealed class RegisterCategoryMapper : Profile
{
    public RegisterCategoryMapper()
    {
        CreateMap<CreateCategoryRequest, Category>();
        CreateMap<Category, CreateCategoryResponse>();
    }
}