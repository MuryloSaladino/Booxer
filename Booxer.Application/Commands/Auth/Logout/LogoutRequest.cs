using MediatR;
using Booxer.Application.Attributes;

namespace Booxer.Application.Commands.Auth.Logout;

[Authenticate]
public sealed record LogoutRequest : IRequest;