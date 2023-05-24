using System.ComponentModel.DataAnnotations;

namespace GhostNetFishing.GhostNets
{
    public class GhostNetRequestDto
    {
        [Required]
        public string Standort { get; set; }
        [Required]
        public string EstimatedSize { get; set; }
        [Required]
        public int GhostNetStatusId { get; set; }
    }
}
