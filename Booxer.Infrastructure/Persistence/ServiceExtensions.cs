using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.Configuration;
using Booxer.Domain.Repository;
using Booxer.Domain.Repository.RefreshTokens;
using Booxer.Domain.Repository.Users;
using Booxer.Infrastructure.Persistence.Context;
using Booxer.Infrastructure.Persistence.Repository;
using Booxer.Infrastructure.Persistence.Repository.RefreshTokens;
using Booxer.Infrastructure.Persistence.Repository.Users;

namespace Booxer.Infrastructure.Persistence;

public static class ServiceExtensions
{
    public static void ConfigurePersistence(this IServiceCollection services)
    {
        var dbUrl = Environment.GetEnvironmentVariable("DATABASE_URL")
            ?? throw new InvalidConfigurationException("Missing \"DATABASE_URL\" environment variable");

        services.AddDbContext<BooxerContext>(opt => opt.UseSqlServer(dbUrl));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IUsersRepository, UserRepository>();
        services.AddScoped<IRefreshTokensRepository, RefreshTokensRepository>();
    }
}