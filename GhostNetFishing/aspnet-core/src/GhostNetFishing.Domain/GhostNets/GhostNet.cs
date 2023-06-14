using GhostNetFishing.GhostNetAndPersons;
using GhostNetFishing.GhostNetStatuses;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace GhostNetFishing.GhostNets
{
    public class GhostNet : Entity<int>
    {
        public string Standort { get; set; }
        public string EstimatedSize { get; set; }
        public int GhostNetStatusId { get; set; }
        public GhostNetStatus GhostNetStatus { get; set; }

        public ICollection<GhostNetAndPerson> GhostNetAndPerson { get; set; }
    }
}
