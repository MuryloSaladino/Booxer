using AutoMapper;
using MediatR;
using Booxer.Domain.Entities;
using Booxer.Domain.Repository;
using Booxer.Domain.Repository.Users;

namespace Booxer.Application.Modules.Users.FindOne;

public sealed class FindOneUserHandler(
    IUsersRepository userRepository,
    IMapper mapper
) : IRequestHandler<FindOneUserRequest, FindOneUserResponse>
{
    public async Task<FindOneUserResponse> Handle(
        FindOneUserRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.FindOne(request.UserId, cancellationToken)
            ?? throw new EntityNotFoundException<User>();

        return mapper.Map<FindOneUserResponse>(user);
    }
}