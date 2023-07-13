using System.ComponentModel.DataAnnotations;

namespace GhostNetFishing.GhostNets
{
    public class GhostNetRequestDto
    {
        [Required]
        public int? Id { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string EstimatedSize { get; set; }
        [Required]
        public int GhostNetStatusId { get; set; }
    }
}
