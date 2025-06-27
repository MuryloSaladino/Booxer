using AutoMapper;
using MediatR;
using Booxer.Domain.Repository.Users;

namespace Booxer.Application.Users.Commands.FindOne;

public sealed class FindOneUserHandler(
    IUsersRepository userRepository,
    IMapper mapper
) : IRequestHandler<FindOneUserRequest, FindOneUserResponse>
{
    public async Task<FindOneUserResponse> Handle(
        FindOneUserRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.FindOne(new() { Id = request.UserId }, cancellationToken);

        return mapper.Map<FindOneUserResponse>(user);
    }
}