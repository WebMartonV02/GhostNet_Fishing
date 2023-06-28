namespace GhostNetFishing.Permissions;

public static class GhostNetFishingPermissions
{
    public const string GroupName = "GhostNetFishing";

    public static class GhostNet
    {
        public const string Default = GroupName + ".GhostNet";
        public const string Reporting = Default + ".Reporting";
        public const string Salvaging = Default + ".Salvaging";
    }

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";
}
