using Microsoft.Extensions.DependencyInjection;
using Booxer.Domain.Identity;
using Booxer.Infrastructure.Identity.Context;
using Booxer.Infrastructure.Identity.Services;

namespace Booxer.Infrastructure.Identity;

public static class ServiceExtensions
{
    public static void ConfigureIdentity(this IServiceCollection services)
    {
        services.AddScoped<IPasswordEncrypter, PasswordEncrypter>();
        services.AddScoped<ITokenAuthenticator, TokenAuthenticator>();
        
        services.AddScoped<ISessionContext, SessionContext>();
    }
}