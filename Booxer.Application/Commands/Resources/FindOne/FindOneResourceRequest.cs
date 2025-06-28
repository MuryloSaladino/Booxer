using MediatR;

namespace Booxer.Application.Commands.Resources.FindOne;

public sealed record FindOneResourceRequest(
    Guid ResourceId
) : IRequest<FindOneResourceResponse>;
