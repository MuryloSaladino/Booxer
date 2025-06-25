using System.Reflection;
using MediatR;
using Booxer.Domain.Identity;
using Booxer.Domain.Repository.RefreshTokens;
using Booxer.Domain.Repository;

namespace Booxer.Application.Pipeline.Authentication;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class AuthenticateAttribute : Attribute
{
    public bool AdminOnly { get; init; }
}

public class AuthenticationBehavior<TRequest, TResponse>(
    IRefreshTokensRepository refreshTokensRepository,
    ITokenAuthenticator tokenAuthenticator,
    ISessionContext session,
    IUnitOfWork unitOfWork
) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var authAttribute = request.GetType().GetCustomAttribute<AuthenticateAttribute>();

        if (authAttribute is not null)
        {
            // Access token authentication
            if (session.AccessToken is string accessToken)
            {
                var tokenPayload = tokenAuthenticator.Extract(accessToken);

                if (authAttribute.AdminOnly && !tokenPayload.IsAdmin)
                    throw new NotAdminException();

                session.UserId = tokenPayload.UserId;
            }
            // Refresh token authentication
            else
            {
                if (session.RefreshToken is null)
                    throw new AuthenticationException("Refresh token not provided.");

                var refreshTokenEntity = await refreshTokensRepository
                    .FindOneValid(session.RefreshToken, cancellationToken);

                if (authAttribute.AdminOnly && !refreshTokenEntity.User.IsAdmin)
                    throw new NotAdminException();

                refreshTokenEntity.Rotate();
                await unitOfWork.Save(cancellationToken);

                session.RefreshToken = refreshTokenEntity.Value;
                session.AccessToken = tokenAuthenticator.GenerateToken(TokenPayload.FromUser(refreshTokenEntity.User));
                session.UserId = refreshTokenEntity.UserId;
            }
        }
        return await next();
    }
}