using System;
using System.Collections.Generic;
using Microsoft.Extensions.Diagnostics.HealthChecks;


namespace Gather.Models
{
  public class Item
  {
    public int ItemId { get; set; }
    public string ItemName { get; set; }
    public List<VendorItems> VendorItems { get; }
    public List<GuestItems> GuestItems { get; }
    public List<GatheringItems> GatheringItems { get; }
  }
}