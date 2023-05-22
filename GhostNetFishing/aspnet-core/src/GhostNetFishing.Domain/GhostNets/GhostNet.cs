using GhostNetFishing.GhostNetsAndPersonen;
using GhostNetFishing.Statuses;
using Volo.Abp.Domain.Entities;

namespace GhostNetFishing.GhostNets
{
    public class GhostNet :  Entity<int>
    {
        public string Standort { get; set; }
        public string EstimatedSize { get; set; }
        public StatusEnum GhostNetStatus { get; set; }

        public GhostNetAndPerson GhostNetAndPerson { get; set; }
    }
}
