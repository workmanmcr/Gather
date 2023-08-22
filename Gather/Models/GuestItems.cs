namespace Gather.Models
{
    public class GuestItems
    {
        public int GuestItemsId { get; set; }
        public ApplicationUser User { get; set; }
        public int UserId { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; }
    }
}