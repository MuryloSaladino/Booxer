using AutoMapper;
using MediatR;
using Booxer.Domain.Identity;
using Booxer.Domain.Entities;
using Booxer.Domain.Repository;
using Booxer.Domain.Repository.Users;

namespace Booxer.Application.Commands.Users.Create;

public sealed class CreateUserHandler(
    IUsersRepository userRepository,
    IPasswordEncrypter encrypter,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    public async Task<CreateUserResponse> Handle(
        CreateUserRequest request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<User>(request);
        user.Password = encrypter.Hash(user.Password);
        
        userRepository.Create(user);
        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CreateUserResponse>(user);
    }
}