using Booxer.Application.Common.Attributes;
using MediatR;

namespace Booxer.Application.Categories.Commands.Create;

[Authenticate(AdminOnly = true)]
public sealed record CreateCategoryRequest(
    string Name
) : IRequest<CreateCategoryResponse>;