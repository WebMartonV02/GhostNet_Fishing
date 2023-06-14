using GhostNetFishing.GhostNets;
using GhostNetFishing.Persons;
using Volo.Abp.Domain.Entities;

namespace GhostNetFishing.GhostNetAndPersons
{
    public class GhostNetAndPerson : Entity<int>
    {
        public int GhostNetId { get; set; }
        public GhostNet GhostNet { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
