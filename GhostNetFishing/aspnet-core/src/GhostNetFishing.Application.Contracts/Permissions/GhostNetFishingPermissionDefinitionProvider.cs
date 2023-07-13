using GhostNetFishing.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace GhostNetFishing.Permissions;

public class GhostNetFishingPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(GhostNetFishingPermissions.GroupName);

        var ghostNetPermissionen = myGroup.AddPermission(GhostNetFishingPermissions.GhostNet.Default, L("Permission:GeisterNetz"));
        ghostNetPermissionen.AddChild(GhostNetFishingPermissions.GhostNet.Meldende, L("Permission:GeisterNetz.Meldende"));
        ghostNetPermissionen.AddChild(GhostNetFishingPermissions.GhostNet.Bergende, L("Permission:GeisterNetz.Bergende"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<GhostNetFishingResource>(name);
    }
}
