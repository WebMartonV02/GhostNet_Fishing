using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GhostNetFishing.Data;
using Volo.Abp.DependencyInjection;

namespace GhostNetFishing.EntityFrameworkCore;

public class EntityFrameworkCoreGhostNetFishingDbSchemaMigrator
    : IGhostNetFishingDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreGhostNetFishingDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the GhostNetFishingDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<GhostNetFishingDbContext>()
            .Database
            .MigrateAsync();
    }
}
