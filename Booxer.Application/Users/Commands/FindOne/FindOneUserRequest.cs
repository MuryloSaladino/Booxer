using Booxer.Application.Common.Attributes;
using MediatR;

namespace Booxer.Application.Users.Commands.FindOne;

[Authenticate]
public sealed record FindOneUserRequest(
    Guid UserId
) : IRequest<FindOneUserResponse>;