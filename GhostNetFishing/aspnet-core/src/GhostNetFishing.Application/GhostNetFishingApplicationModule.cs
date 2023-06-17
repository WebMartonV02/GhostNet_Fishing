using GhostNetFishing.GhostNets;
using GhostNetFishing.Persons;
using GhostNetFishing.Repositories.Common;
using GhostNetFishing.Repositories.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace GhostNetFishing;

[DependsOn(
    typeof(GhostNetFishingDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(GhostNetFishingApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class GhostNetFishingApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<GhostNetFishingApplicationModule>();
        });
        
        //context.Services.AddTransient<DefaultRepository<GhostNet>>(); //register ioc for generic solution
        context.Services.AddTransient<IDefaultRepository<GhostNet>, DefaultRepository<GhostNet>>(); //register ioc for generic solution -- try that out
        context.Services.AddTransient<IDefaultRepository<Person>, DefaultRepository<Person>>(); //register ioc for generic solution -- try that out
    }
}
