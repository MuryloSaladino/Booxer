using MediatR;
using Booxer.Application.Common.Attributes;

namespace Booxer.Application.Auth.Commands.Logout;

[Authenticate]
public sealed record LogoutRequest : IRequest;