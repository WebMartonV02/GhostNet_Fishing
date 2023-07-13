using System;
using System.ComponentModel.DataAnnotations;

namespace GhostNetFishing.GhostNetsAndPersons
{
    public class GhostNetAndPersonRequestDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int GhostNetId { get; set; }
        [Required]
        public Guid UserId { get; set; }
    }
}
