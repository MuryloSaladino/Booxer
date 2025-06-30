using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Booxer.Domain.Entities;

namespace Booxer.Infrastructure.Persistence.Seeding;

public static class SeedingExtensions
{
    private static readonly string DemoPassword = "12345678";
    private static readonly PasswordHasher<User> hasher = new();

    public static async Task UseDemoSeeding(this DbContext context)
    {
        // -------------- USERS -------------- //
        var users = context.Set<User>();
        if (await users.AnyAsync()) return;
        
        var hashedPassword = hasher.HashPassword(null!, DemoPassword);

        users.Add(new()
        {
            Username = "admin",
            Password = hashedPassword,
            Email = "admin@mail.com",
            IsAdmin = true,
        });

        List<string> usernames = ["sau8ct", "mek1ct", "lua2ct", "agy1ct"];
        List<User> userList = [..usernames.Select(u => new User()
        {
            Username = u,
            Password = hashedPassword,
            Email = $"{u}@mail.com",
        })];
        users.AddRange(userList);

        // -------------- RESOURCES -------------- //
        var categories = context.Set<Category>();
        var resources = context.Set<Resource>();
        List<Resource> resourceList = [];

        var resourcesDict = new Dictionary<string, List<string>>()
        {
            { "Vehicles", ["RAM Rampage 2022","GMC S10 2025","VW Saveiro 2010","HM HR-V 2023"] },
            { "Conference Rooms", ["Oak Room","Maple Hall","Cambridge Room","Justice Room","Hearth Room"] },
            { "Notebooks", ["Dell Alienware","Apple MacbookAir","Apple MacbookPro","Lenovo T14"] },
        };

        foreach (var (c, r) in resourcesDict)
        {
            var category = new Category() { Name = c };
            categories.Add(category);
            resourceList.AddRange(r.Select(s => new Resource()
            {
                Category = category,
                CategoryId = category.Id,
                Name = s,
            }));
        }
        resources.AddRange(resources);

        // -------------- RESERVATIONS -------------- //
        var reservations = context.Set<Reservation>();
        var random = new Random();

        foreach (var resource in resourceList)
        {
            for (int i = -14; i < 15; i++)
            {
                var day = DateTime.Today.AddDays(i);
                var startHour = random.Next(8, 19);
                var endHour = Math.Min(startHour + random.Next(1, 8), 18);
                var startsAt = new DateTime(day.Year, day.Month, day.Day, startHour, 0, 0);
                var endsAt = new DateTime(day.Year, day.Month, day.Day, endHour, 0, 0);
                var user = userList[random.Next(userList.Count)];

                reservations.Add(new()
                {
                    ReservedById = user.Id,
                    ReservedBy = user,
                    ResourceId = resource.Id,
                    Resource = resource,
                    StartsAt = startsAt,
                    EndsAt = endsAt,
                });
            }
        }
        await context.SaveChangesAsync();
    }
}