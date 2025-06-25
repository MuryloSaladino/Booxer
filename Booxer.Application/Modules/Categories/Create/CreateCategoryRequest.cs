using Booxer.Application.Pipeline.Authentication;
using MediatR;

namespace Booxer.Application.Modules.Categories.Create;

[Authenticate(AdminOnly = true)]
public sealed record CreateCategoryRequest(
    string Name
) : IRequest<CreateCategoryResponse>;