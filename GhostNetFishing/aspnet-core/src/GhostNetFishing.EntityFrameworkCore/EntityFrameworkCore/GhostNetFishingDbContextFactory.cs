using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace GhostNetFishing.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class GhostNetFishingDbContextFactory : IDesignTimeDbContextFactory<GhostNetFishingDbContext>
{
    public GhostNetFishingDbContext CreateDbContext(string[] args)
    {
        GhostNetFishingEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<GhostNetFishingDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new GhostNetFishingDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../GhostNetFishing.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
