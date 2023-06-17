using GhostNetFishing.GhostNets;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace GhostNetFishing.GhostNetStatuses
{
    public class GhostNetStatus : Entity<int>
    {
        public string Type { get; set; }

        public ICollection<GhostNet> GhostNets { get; set; }

        public GhostNetStatus(string type)
        {
            Type = type;
        }
    }
}
