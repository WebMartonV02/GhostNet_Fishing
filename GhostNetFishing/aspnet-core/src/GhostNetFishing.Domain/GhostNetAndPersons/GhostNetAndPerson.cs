using GhostNetFishing.GhostNets;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;

namespace GhostNetFishing.GhostNetAndPersons
{
    public class GhostNetAndPerson : Entity<int>
    {
        public int GhostNetId { get; set; }
        public GhostNet GhostNet { get; set; }
        public Guid UserId { get; set; }
        public IdentityUser User { get; set; }

        public GhostNetAndPerson(int ghostNetId, GhostNet ghostNet) 
        {
            GhostNetId = ghostNetId;
            GhostNet = ghostNet;
        }

        public GhostNetAndPerson(
            int ghostNetId,
            Guid userId)
        {
            GhostNetId = ghostNetId;
            UserId = userId;
        }

        public GhostNetAndPerson Update(
            int ghostNetId,
            Guid userId)
        {
            GhostNetId = ghostNetId;
            UserId = userId;

            return this;
        }
    }
}
