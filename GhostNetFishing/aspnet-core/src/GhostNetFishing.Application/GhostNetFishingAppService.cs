using System;
using System.Collections.Generic;
using System.Text;
using GhostNetFishing.Localization;
using Volo.Abp.Application.Services;

namespace GhostNetFishing;

/* Inherit your application services from this class.
 */
public abstract class GhostNetFishingAppService : ApplicationService
{
    protected GhostNetFishingAppService()
    {
        LocalizationResource = typeof(GhostNetFishingResource);
    }
}
