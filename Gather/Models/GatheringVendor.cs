using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gather.Models
{
  public class GatheringVendor
  {
    public int GatheringVendorId { get; set; }

    public Gathering Gathering { get; set; }
    public int GatheringId { get; set; }
    public Vendor Vendor { get; set; }
    public int VendorId { get; set; }
  }
}