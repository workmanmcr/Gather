using System.Collections.Generic;

namespace Gather.Models
{
  public class User
  {
    public int UserId { get; set; }
    public string Name { get ; set; }
    public List<EventUser> JoinUsers { get; }
  }
}