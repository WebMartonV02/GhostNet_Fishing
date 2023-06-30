using System;

namespace GhostNetFishing.GhostNetsAndPersons
{
    public class GhostNetAndPersonRequestDto
    {
        public int Id { get; set; }
        public int GhostNetId { get; set; }
        public Guid PersonId { get; set; }

    }
}
