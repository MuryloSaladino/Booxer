using MediatR;

namespace Booxer.Application.Auth.Commands.Login;

public sealed record LoginRequest(
    string UsernameOrEmail,
    string Password
) : IRequest;
