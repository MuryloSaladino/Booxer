using Booxer.Application.Attributes;
using MediatR;

namespace Booxer.Application.Commands.Auth.ReadSelfDetails;

[Authenticate]
public sealed record ReadSelfDetailsRequest : IRequest<ReadSelfDetailsResponse>;
