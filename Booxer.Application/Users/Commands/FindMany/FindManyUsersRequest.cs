using MediatR;
using Booxer.Domain.Repository.Users;
using Booxer.Application.Common.Attributes;

namespace Booxer.Application.Users.Commands.FindMany;

[Authenticate(AdminOnly = true)]
public sealed record FindManyUsersRequest
    : UserFilter, IRequest<List<FindManyUsersResponse>>;