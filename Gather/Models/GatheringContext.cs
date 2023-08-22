using System.Diagnostics;
using System.Diagnostics.Tracing;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gather.Models
{
    public class GatherContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Gathering> Gatherings { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<ApplicationUser> AspNetUsers { get; set; }
        public DbSet<Item> Items { get; set; }

        public DbSet<GatheringUser> GatheringUsers { get; set; }
        public DbSet<GatheringActivity> GatheringActivities { get; set; }
        public DbSet<GatheringVendor> GatheringVendors { get; set; }
        public DbSet<UserVendor> UserVendors { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }
        public DbSet<VendorItems> VendorItems { get; set; }
        public DbSet<GuestItems> GuestItems { get; set; }
        public DbSet<GatheringItems> GatheringItems { get; set; }

        public GatherContext(DbContextOptions options) : base(options) { }
    }
}