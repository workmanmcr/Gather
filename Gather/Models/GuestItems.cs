namespace Gather.Models
{
    public class GuestItem
    {
        public int GuestItemId { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; }
    }
}