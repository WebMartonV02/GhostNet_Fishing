using GhostNetFishing.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace GhostNetFishing.Permissions;

public class GhostNetFishingPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(GhostNetFishingPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(GhostNetFishingPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<GhostNetFishingResource>(name);
    }
}
