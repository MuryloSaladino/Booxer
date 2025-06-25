using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.Configuration;
using Booxer.Domain.Entities;
using Booxer.Infrastructure.Persistence.Context;

namespace Booxer.Infrastructure.Persistence.Seeding;

public static class SeedingExtensions
{
    private static readonly string AdminUsername = Environment.GetEnvironmentVariable("ADMIN_USERNAME")
        ?? throw new InvalidConfigurationException("Missing \"ADMIN_USERNAME\" environment variable");
    private static readonly string AdminEmail = Environment.GetEnvironmentVariable("ADMIN_EMAIL")
        ?? throw new InvalidConfigurationException("Missing \"ADMIN_EMAIL\" environment variable");
    private static readonly string AdminPassword = Environment.GetEnvironmentVariable("ADMIN_PASSWORD")
        ?? throw new InvalidConfigurationException("Missing \"ADMIN_PASSWORD\" environment variable");

    public static async Task SeedData(this BooxerContext context)
    {
        var users = context.Set<User>();
        var adminExists = await users.AnyAsync(u => u.Username == AdminUsername);

        if(!adminExists)
        {
            var adminUser = new User()
            {
                Username = AdminUsername,
                Password = AdminPassword,
                Email = AdminEmail,
                IsAdmin = true
            };

            PasswordHasher<User> hasher = new();
            adminUser.Password = hasher.HashPassword(adminUser, adminUser.Password); 
            
            users.Add(adminUser);
        }

        await context.SaveChangesAsync();
    }
}