using Volo.Abp.Modularity;

namespace GhostNetFishing;

[DependsOn(
    typeof(GhostNetFishingApplicationModule),
    typeof(GhostNetFishingDomainTestModule)
    )]
public class GhostNetFishingApplicationTestModule : AbpModule
{

}
