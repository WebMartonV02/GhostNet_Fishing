using System.Threading.Tasks;

namespace GhostNetFishing.Data;

public interface IGhostNetFishingDbSchemaMigrator
{
    Task MigrateAsync();
}
