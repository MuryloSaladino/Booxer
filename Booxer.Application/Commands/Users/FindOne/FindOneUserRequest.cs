using Booxer.Application.Attributes;
using MediatR;

namespace Booxer.Application.Commands.Users.FindOne;

[Authenticate]
public sealed record FindOneUserRequest(
    Guid UserId
) : IRequest<FindOneUserResponse>;