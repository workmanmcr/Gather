namespace Gather.Models
{
    public class VendorItems
    {
        public int VendorItemsId { get; set; }
        public Vendor Vendor { get; set; }
        public int VendorId { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; }
    }
}