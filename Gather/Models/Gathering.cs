using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gather.Models
{
  public class Gathering
  {
    public int GatheringId { get; set; }
    public string Title { get; set; }

    public string Location { get; set; }
    public int DateTime { get; set; }
    public int About { get; set; }
    public List<GatheringUser> GatheringUsers { get; }
    public List<GatheringVendor> GatheringVendors { get; }
    public List<GatheringActivity> GatheringActivities { get; }
    public List<GatheringItem> GatheringsItems { get; }
  }
}