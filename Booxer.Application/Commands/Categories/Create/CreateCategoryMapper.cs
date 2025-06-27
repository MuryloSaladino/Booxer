using AutoMapper;
using Booxer.Domain.Entities;

namespace Booxer.Application.Commands.Categories.Create;

public sealed class RegisterCategoryMapper : Profile
{
    public RegisterCategoryMapper()
    {
        CreateMap<CreateCategoryRequest, Category>();
        CreateMap<Category, CreateCategoryResponse>();
    }
}