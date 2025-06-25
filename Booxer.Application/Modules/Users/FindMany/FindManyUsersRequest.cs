using MediatR;
using Booxer.Application.Pipeline.Authentication;

namespace Booxer.Application.Modules.Users.FindMany;

[Authenticate(AdminOnly = true)]
public sealed record FindManyUsersRequest : IRequest<List<FindManyUsersResponse>>;