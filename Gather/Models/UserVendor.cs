using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gather.Models
{
  public class UserVendor
  {
    public int UserVendorId { get; set; }

    public Vendor Vendor { get; set; }
    public int VendorId { get; set; }
    public ApplicationUser User { get; set; }
    public int ApplicationUserId { get; set; }
  }
}