namespace Gather.Models
{
    public class GatheringItems
    {
        public int GatheringsItemsId { get; set; }
        public Gathering Gathering { get; set; }
        public int GatheringId { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; }
    }
}