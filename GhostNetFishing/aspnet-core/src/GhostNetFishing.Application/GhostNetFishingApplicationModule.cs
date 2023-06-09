﻿using GhostNetFishing.Common.Interfaces;
using GhostNetFishing.Repositories.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
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
        
        context.Services.AddTransient(typeof(IDefaultRepository<>), typeof(DefaultRepository<>));
    }
}
