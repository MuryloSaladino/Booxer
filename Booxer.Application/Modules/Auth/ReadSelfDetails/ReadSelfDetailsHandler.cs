using AutoMapper;
using Booxer.Domain.Identity;
using Booxer.Domain.Repository.Users;
using MediatR;

namespace Booxer.Application.Modules.Auth.ReadSelfDetails;

public class ReadSelfDetailsHandler(
    IUsersRepository usersRepository,
    ISessionContext session,
    IMapper mapper
) : IRequestHandler<ReadSelfDetailsRequest, ReadSelfDetailsResponse>
{
    public async Task<ReadSelfDetailsResponse> Handle(
        ReadSelfDetailsRequest request, CancellationToken cancellationToken)
    {
        var user = await usersRepository.FindOne(new() { Id = session.GetUserIdOrThrow() }, cancellationToken);

        return mapper.Map<ReadSelfDetailsResponse>(user);
    }
}
