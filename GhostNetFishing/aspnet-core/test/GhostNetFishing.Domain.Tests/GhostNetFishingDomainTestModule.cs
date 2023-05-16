using GhostNetFishing.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace GhostNetFishing;

[DependsOn(
    typeof(GhostNetFishingEntityFrameworkCoreTestModule)
    )]
public class GhostNetFishingDomainTestModule : AbpModule
{

}
