using Booxer.Application.Common.Attributes;
using MediatR;

namespace Booxer.Application.Resources.Commands.Create;

[Authenticate(AdminOnly = true)]
public sealed record CreateResourceRequest(
    Guid CategoryId,
    string Name
) : IRequest<CreateResourceResponse>;