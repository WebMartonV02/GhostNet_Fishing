using GhostNetFishing.GhostNetsAndPersonen;
using System.Collections;
using Volo.Abp.Domain.Entities;

namespace GhostNetFishing.GhostNets
{
    public class GhostNetStatus : Entity<int>
    {
        public string Type { get; set; }

        public ICollection<GhostNetAndPerson> GhostNetAndPersons { get; set; }
    }
}
