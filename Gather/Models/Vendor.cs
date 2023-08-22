using System;
using System.Collections.Generic;

namespace Gather.Models
{
  public class Vendor
  {
    public int VendorId { get; set; }
    public string VendorName { get; set; }
    public string About { get; set; }
    public List<VendorItems> VendorsItems { get; }
    public List<GatheringVendor> GatheringVendors { get; }
    public List<UserVendor> UserVendors { get; }
  }
}
