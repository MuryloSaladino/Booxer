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
using Booxer.Domain.Repository.Resources;
using Booxer.Infrastructure.Persistence.Repository.Resources;
using Booxer.Domain.Repository.Categories;
using Booxer.Infrastructure.Persistence.Repository.Categories;
using Booxer.Domain.Repository.Reservations;
using Booxer.Infrastructure.Persistence.Repository.Reservations;
using Booxer.Infrastructure.Persistence.Seeding;

namespace Booxer.Infrastructure.Persistence;

public static class ServiceExtensions
{
    public static void ConfigurePersistence(this IServiceCollection services)
    {
        services.AddDbContext<BooxerContext>(opt =>
        {
            var dbUrl = Environment.GetEnvironmentVariable("DATABASE_URL")
                ?? throw new InvalidConfigurationException("Missing \"DATABASE_URL\" environment variable");

            opt.UseSqlServer(dbUrl);

            if(Environment.GetEnvironmentVariable("ENV") == "dev")
                opt.UseAsyncSeeding(async (ctx, b, cancellationToken) => await ctx.UseDemoSeeding());
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUsersRepository, UserRepository>();
        services.AddScoped<IRefreshTokensRepository, RefreshTokensRepository>();
        services.AddScoped<IResourcesRepository, ResourcesRepository>();
        services.AddScoped<ICategoriesRepository, CategoriesRepository>();
        services.AddScoped<IReservationsRepository, ReservationsRepository>();
    }
}