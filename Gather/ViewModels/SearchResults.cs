using Gather.Models;
namespace Gather.ViewModels
{
    public class SearchResults
    {
        public List<Event> EventResults { get; set; }
        public List<Activity> ActivityResults { get; set; }
        public List<VendorItem> VendorItemResults { get; set; }
        public List<GuestItem> UserItemResults { get; set; }
        public List<Vendor> VendorResults { get; set; }
    }
}