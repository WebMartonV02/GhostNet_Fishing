using Volo.Abp.Settings;

namespace GhostNetFishing.Settings;

public class GhostNetFishingSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(GhostNetFishingSettings.MySetting1));
    }
}
