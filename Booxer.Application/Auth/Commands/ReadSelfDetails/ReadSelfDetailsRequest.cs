using Booxer.Application.Common.Attributes;
using MediatR;

namespace Booxer.Application.Auth.Commands.ReadSelfDetails;

[Authenticate]
public sealed record ReadSelfDetailsRequest : IRequest<ReadSelfDetailsResponse>;
