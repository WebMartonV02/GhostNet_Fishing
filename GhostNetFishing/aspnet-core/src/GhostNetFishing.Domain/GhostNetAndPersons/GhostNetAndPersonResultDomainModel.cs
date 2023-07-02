using GhostNetFishing.GhostNets;
using Volo.Abp.Identity;

namespace GhostNetFishing.GhostNetAndPersons
{
    public class GhostNetAndPersonResultDomainModel
    {
        public GhostNet GhostNet { get; set; }
        public IdentityUser User { get; set; }
    }
}
