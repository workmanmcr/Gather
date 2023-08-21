using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gather.Models
{
  public class Event
  {
    public int EventId { get; set; }
    public string Title { get; set; }
  
    public string Location { get; set; }
    public int TimeDate { get; set; }
    public int About { get; set; }
  }
}