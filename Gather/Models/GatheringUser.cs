using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gather.Models
{
  public class GatheringUser
  {
    public int GatheringUserId { get; set; }
    public Gathering Gathering { get; set; }
    public int GatheringId { get; set; }
    public ApplicationUser User { get; set; }
    public int ApplicationUserId { get; set; }
  }
}