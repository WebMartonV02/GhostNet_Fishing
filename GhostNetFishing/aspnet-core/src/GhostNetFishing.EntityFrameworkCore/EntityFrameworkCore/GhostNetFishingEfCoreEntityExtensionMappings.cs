using GhostNetFishing.User;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;

namespace GhostNetFishing.EntityFrameworkCore;

public static class GhostNetFishingEfCoreEntityExtensionMappings
{
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    public static void Configure()
    {
        GhostNetFishingGlobalFeatureConfigurator.Configure();
        GhostNetFishingModuleExtensionConfigurator.Configure();

        OneTimeRunner.Run(() =>
        {
            ObjectExtensionManager.Instance
                .MapEfCoreProperty<IdentityUser, string>(
                    UserConsts.TELEFONNUMBER,
                    (_, propertyBuilder) => 
                    {
                    })
                .MapEfCoreProperty<IdentityUser, int>(
                    UserConsts.PERSONTYPEID,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.HasDefaultValue(1);
                    });
        });
    }
}
