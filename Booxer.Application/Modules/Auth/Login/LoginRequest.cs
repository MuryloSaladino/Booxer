using MediatR;

namespace Booxer.Application.Modules.Auth.Login;

public sealed record LoginRequest(
    string UsernameOrEmail,
    string Password
) : IRequest;
