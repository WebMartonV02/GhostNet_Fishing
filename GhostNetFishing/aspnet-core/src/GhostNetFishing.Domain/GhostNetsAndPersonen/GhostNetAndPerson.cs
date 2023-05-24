using GhostNetFishing.GhostNets;
using GhostNetFishing.Personen;
using Volo.Abp.Domain.Entities;

namespace GhostNetFishing.GhostNetsAndPersonen
{
    public class GhostNetAndPerson : Entity<int>
    {
        public int GhostNetId { get; set; }
        public GhostNetStatus GhostNet { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
