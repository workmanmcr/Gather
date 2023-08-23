using System;
using System.Collections.Generic;
using Microsoft.Extensions.Diagnostics.HealthChecks;


namespace Gather.Models
{
  public class Guest
  {
    public int GuestId { get; set; }
    public string Name { get; set; }
    public List<VendorItem> VendorItems { get; }
    public List<GuestItem> GuestItems { get; }
    public List<GatheringItem> GatheringItems { get; }
  }
}