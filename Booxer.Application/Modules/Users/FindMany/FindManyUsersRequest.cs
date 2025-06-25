using MediatR;
using Booxer.Application.Pipeline.Authentication;
using Booxer.Domain.Repository.Users;

namespace Booxer.Application.Modules.Users.FindMany;

[Authenticate(AdminOnly = true)]
public sealed record FindManyUsersRequest
    : UserFilter, IRequest<List<FindManyUsersResponse>>;