using GhostNetFishing.GhostNetStatuses;

namespace GhostNetFishing.GhostNets
{
    public class GhostNetResultDto
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string EstimatedSize { get; set; }
        public int GhostNetStatusId { get; set; }
        public GhostNetStatusResultDto GhostNetStatus { get; set; }
    }
}
