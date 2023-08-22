namespace Gather.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<GatheringActivity> GatheringActivities { get; }
        public List<UserActivity> UserActivities { get; }
    }
}