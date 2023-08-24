namespace Gather.Models
{
    public class GatheringItem
    {
        public int GatheringItemId { get; set; }
        public Gathering Gathering { get; set; }
        public int GatheringId { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; }
    }
}