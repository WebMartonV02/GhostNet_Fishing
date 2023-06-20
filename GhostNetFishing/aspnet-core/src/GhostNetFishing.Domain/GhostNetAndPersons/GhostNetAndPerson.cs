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

        public GhostNetAndPerson(int ghostNetId, GhostNet ghostNet) 
        {
            GhostNetId = ghostNetId;
            GhostNet = ghostNet;
        }

        public GhostNetAndPerson(
            int ghostNetId,
            int personId)
        {
            GhostNetId = ghostNetId;
            PersonId = personId;
        }

        public GhostNetAndPerson Update(
            int ghostNetId,
            int personId)
        {
            GhostNetId = ghostNetId;
            PersonId = personId;

            return this;
        }
    }
}
