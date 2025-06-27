using MediatR;

namespace Booxer.Application.Commands.Auth.Login;

public sealed record LoginRequest(
    string UsernameOrEmail,
    string Password
) : IRequest;
