using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace GhostNetFishing.Data;

/* This is used if database provider does't define
 * IGhostNetFishingDbSchemaMigrator implementation.
 */
public class NullGhostNetFishingDbSchemaMigrator : IGhostNetFishingDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
