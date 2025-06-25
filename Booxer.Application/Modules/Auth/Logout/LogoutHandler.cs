using MediatR;
using Booxer.Domain.Identity;
using Booxer.Domain.Repository.RefreshTokens;
using Booxer.Domain.Repository;

namespace Booxer.Application.Modules.Auth.Logout;

public class LogoutHandler(
    IRefreshTokensRepository refreshTokensRepository,
    ISessionContext session,
    IUnitOfWork unitOfWork
) : IRequestHandler<LogoutRequest>
{
    public async Task Handle(LogoutRequest request, CancellationToken cancellationToken)
    {
        if (session.RefreshToken is string token)
        {
            (await refreshTokensRepository.FindOneValid(token, cancellationToken)).Invalidate();
            await unitOfWork.Save(cancellationToken);
        }
        
        session.AccessToken = null;
        session.RefreshToken = null;
    }
}
