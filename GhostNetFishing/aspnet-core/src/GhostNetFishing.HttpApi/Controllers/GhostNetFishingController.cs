using GhostNetFishing.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace GhostNetFishing.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class GhostNetFishingController : AbpControllerBase
{
    protected GhostNetFishingController()
    {
        LocalizationResource = typeof(GhostNetFishingResource);
    }
}
