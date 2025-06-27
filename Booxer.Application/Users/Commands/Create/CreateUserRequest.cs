using MediatR;

namespace Booxer.Application.Users.Commands.Create;

public sealed record CreateUserRequest(
    string Username,
    string Email,
    string Password
) : IRequest<CreateUserResponse>;
