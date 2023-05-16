using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace GhostNetFishing;

[Dependency(ReplaceServices = true)]
public class GhostNetFishingBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "GhostNetFishing";
}
