using Booxer.Application.Attributes;
using MediatR;

namespace Booxer.Application.Commands.Categories.Create;

[Authenticate(AdminOnly = true)]
public sealed record CreateCategoryRequest(
    string Name
) : IRequest<CreateCategoryResponse>;