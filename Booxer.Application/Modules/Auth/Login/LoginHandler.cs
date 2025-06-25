using MediatR;
using Booxer.Domain.Repository.Users;
using Booxer.Domain.Identity;
using Booxer.Domain.Repository.RefreshTokens;
using Booxer.Domain.Entities;
using Booxer.Domain.Repository;
using Booxer.Application.Pipeline.Authentication;

namespace Booxer.Application.Modules.Auth.Login;

public sealed class LoginHandler(
    IRefreshTokensRepository refreshTokensRepository,
    ITokenAuthenticator tokenAuthenticator,
    IUsersRepository userRepository,
    IPasswordEncrypter encrypter,
    ISessionContext session,
    IUnitOfWork unitOfWork
) : IRequestHandler<LoginRequest>
{
    public async Task Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.FindOne(new() { UsernameOrEmail = request.UsernameOrEmail }, cancellationToken);
        
        if(!encrypter.Matches(user.Password, request.Password)) 
            throw new AuthenticationException("Incorrect password or invalid credentials.");

        var refreshToken = await refreshTokensRepository.FindOneOrCreate(user, cancellationToken);
        refreshToken.Rotate();

        await unitOfWork.Save(cancellationToken);

        session.AccessToken = tokenAuthenticator.GenerateToken(TokenPayload.FromUser(user));
        session.RefreshToken = refreshToken.Value;
    }
}