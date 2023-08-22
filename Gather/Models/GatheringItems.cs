namespace Gather.Models
{
    public class GatheringItems
    {
        public int GatheringItemsId { get; set; }
        public Gathering Gathering { get; set; }
        public int GatheringId { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; }
    }
}