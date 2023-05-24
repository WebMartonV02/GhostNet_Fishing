using GhostNetFishing.GhostNetsAndPersonen;
using Volo.Abp.Domain.Entities;

namespace GhostNetFishing.GhostNets
{
    public class GhostNet : Entity<int>
    {
        public string Standort { get; set; }
        public string EstimatedSize { get; set; }
        public int GhostNetStatusId { get; set; }
        public GhostNetStatus GhostNetStatus { get; set; }

        public GhostNetAndPerson GhostNetAndPerson { get; set; }
    }
}
