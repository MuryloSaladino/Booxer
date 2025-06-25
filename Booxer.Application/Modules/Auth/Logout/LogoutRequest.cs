using MediatR;
using Booxer.Application.Pipeline.Authentication;

namespace Booxer.Application.Modules.Auth.Logout;

[Authenticate]
public sealed record LogoutRequest : IRequest;