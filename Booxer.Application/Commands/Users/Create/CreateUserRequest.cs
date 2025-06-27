using MediatR;

namespace Booxer.Application.Commands.Users.Create;

public sealed record CreateUserRequest(
    string Username,
    string Email,
    string Password
) : IRequest<CreateUserResponse>;
