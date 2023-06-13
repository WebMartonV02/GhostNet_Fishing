﻿using GhostNetFishing.GhostNets;
using GhostNetFishing.Personen;
using Volo.Abp.Domain.Entities;

namespace GhostNetFishing.GhostNetsAndPersonen
{
    public class GhostNetAndPerson : Entity<int>
    {
        public int GhostNetId { get; set; }
        public GhostNet GhostNet { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int GhostNetStatusId { get; set; } 
        public GhostNetStatus GhostNetStatus { get; set; } 
    }
}
