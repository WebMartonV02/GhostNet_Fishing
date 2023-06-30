namespace GhostNetFishing.Permissions;

public static class GhostNetFishingPermissions
{
    public const string GroupName = "GhostNetFishing";

    public static class GhostNet
    {
        public const string Default = GroupName + ".GhostNet";
        public const string Reporting = Default + ".Reporting"; // Meldende
        public const string Recovering = Default + ".Recovering"; // Bergende
    }
}
