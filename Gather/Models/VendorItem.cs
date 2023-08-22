using System;
using System.Collections.Generic;
using Microsoft.Extensions.Diagnostics.HealthChecks;


namespace Gather.Models
{
  public class VendorItem
  {
    public int VendorItemId { get; set; }
    public string VendorItemName { get; set; }
  }
}