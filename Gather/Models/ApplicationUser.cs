using Microsoft.AspNetCore.Identity;

namespace Gather.Models
{
  public class ApplicationUser : IdentityUser
  {
    public List<GatheringUser> GatheringUsers { get; }
    public List<UserActivity> UserActivities { get; }
    public List<UserVendor> UserVendors { get; }
    public List<GuestItems> GuestsItems { get; }
  }
}