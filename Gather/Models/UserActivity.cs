using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gather.Models
{
  public class UserActivity
  {
    public int UserActivityId { get; set; }
    public ApplicationUser User { get; set; }
    public int ApplicationUserId { get; set; }
    public Activity Activity { get; set; }
    public int ActivityId { get; set; }
  }
}