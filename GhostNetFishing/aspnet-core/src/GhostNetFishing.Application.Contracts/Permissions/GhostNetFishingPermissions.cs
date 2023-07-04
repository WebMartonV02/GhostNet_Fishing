namespace GhostNetFishing.Permissions;

public static class GhostNetFishingPermissions
{
    public const string GroupName = "GhostNetFishing";

    public static class GhostNet
    {
        public const string Default = GroupName + ".GeisterNetz";
        public const string Meldende = Default + ".Meldende"; 
        public const string Bergende = Default + ".Bergende";
    }
}
