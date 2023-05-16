using GhostNetFishing.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace GhostNetFishing.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(GhostNetFishingEntityFrameworkCoreModule),
    typeof(GhostNetFishingApplicationContractsModule)
    )]
public class GhostNetFishingDbMigratorModule : AbpModule
{

}
