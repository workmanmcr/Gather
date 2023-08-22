namespace Gather.Models
{
    public class GatheringActivity
    {
        public int GatheringActivityId { get; set; }
        public Gathering Gathering {get; set; }
        public int GatheringId { get; set; }
        public Activity Activity { get; set; }
        public int ActivityId { get; set; }
    }
}