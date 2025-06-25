using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.IdentityModel.Protocols.Configuration;

namespace Booxer.Infrastructure.Persistence.Context;

public class BooxerContextFactory : IDesignTimeDbContextFactory<BooxerContext>
{
    public BooxerContext CreateDbContext(string[] args)
    {
        DotEnv.Load(options: new DotEnvOptions(envFilePaths: ["../.env"]));

        var dbUrl = Environment.GetEnvironmentVariable("DATABASE_URL")
            ?? throw new InvalidConfigurationException("Missing \"DATABASE_URL\" environment variable");
        var optionsBuilder = new DbContextOptionsBuilder<BooxerContext>();

        optionsBuilder.UseSqlServer(dbUrl);

        return new BooxerContext(optionsBuilder.Options);
    }
}