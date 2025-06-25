using Booxer.Application.Pipeline.Authentication;
using MediatR;

namespace Booxer.Application.Modules.Resources.Create;

[Authenticate(AdminOnly = true)]
public sealed record CreateResourceRequest(
    Guid CategoryId,
    string Name
) : IRequest<CreateResourceResponse>;