using AutoMapper;
using MediatR;
using Booxer.Domain.Repository.Users;

namespace Booxer.Application.Users.Commands.FindMany;

public sealed class FindManyUsersHandler(
    IUsersRepository userRepository,
    IMapper mapper
) : IRequestHandler<FindManyUsersRequest, List<FindManyUsersResponse>>
{
    public async Task<List<FindManyUsersResponse>> Handle(
        FindManyUsersRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.FindMany(request, cancellationToken);

        return mapper.Map<List<FindManyUsersResponse>>(user);
    }
}