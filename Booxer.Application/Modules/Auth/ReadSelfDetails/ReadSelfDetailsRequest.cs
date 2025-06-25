using Booxer.Application.Pipeline.Authentication;
using MediatR;

namespace Booxer.Application.Modules.Auth.ReadSelfDetails;

[Authenticate]
public sealed record ReadSelfDetailsRequest : IRequest<ReadSelfDetailsResponse>;
