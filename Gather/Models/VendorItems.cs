namespace Gather.Models
{
    public class VendorItem
    {
        public int VendorItemId { get; set; }
        public Vendor Vendor { get; set; }
        public int VendorId { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; }
        
    }
}