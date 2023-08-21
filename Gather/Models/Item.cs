using System;
using System.Collections.Generic;
using Microsoft.Extensions.Diagnostics.HealthChecks;


namespace Gather.Models
{
  public class Item
  {
    public int ItemId { get; set; }
    public string ItemName { get; set; }

    public int UserItemId { get; set; }

    public string UserItemName { get; set; }

    public int VendorItemId { get; set; }

    public string VendorItemName { get; set; }
  
  }
}