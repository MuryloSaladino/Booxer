using MediatR;
using Booxer.Application.Pipeline.Authentication;

namespace Booxer.Application.Modules.Users.FindOne;

[Authenticate]
public sealed record FindOneUserRequest(
    Guid UserId
) : IRequest<FindOneUserResponse>;