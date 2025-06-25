using MediatR;

namespace Booxer.Application.Modules.Users.Create;

public sealed record CreateUserRequest(
    string Username,
    string Email,
    string Password
) : IRequest<CreateUserResponse>;
