using Booxer.Application.Attributes;
using MediatR;

namespace Booxer.Application.Commands.Resources.Create;

[Authenticate(AdminOnly = true)]
public sealed record CreateResourceRequest(
    Guid CategoryId,
    string Name
) : IRequest<CreateResourceResponse>;