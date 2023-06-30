using GhostNetFishing.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace GhostNetFishing.Permissions;

public class GhostNetFishingPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(GhostNetFishingPermissions.GroupName);

        var booksPermission = myGroup.AddPermission(GhostNetFishingPermissions.GhostNet.Default, L("Permission:GhostNet"));
        booksPermission.AddChild(GhostNetFishingPermissions.GhostNet.Reporting, L("Permission:GhostNet.Reporting"));
        booksPermission.AddChild(GhostNetFishingPermissions.GhostNet.Recovering, L("Permission:GhostNet.Recovering"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<GhostNetFishingResource>(name);
    }
}
