using Gather.Models;
namespace Gather.ViewModels
{
    public class SearchResults
    {
        public List<Gathering> GatheringResults { get; set; }
        public List<Activity> ActivityResults { get; set; }
        public List<Item> ItemResults { get; set; }
        public List<Vendor> VendorResults { get; set; }
    }
}