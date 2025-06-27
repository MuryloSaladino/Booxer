using MediatR;
using Booxer.Application.Attributes;
using Booxer.Domain.Repository.Users;

namespace Booxer.Application.Commands.Users.FindMany;

[Authenticate(AdminOnly = true)]
public sealed record FindManyUsersRequest
    : UserFilter, IRequest<List<FindManyUsersResponse>>;