using System.Diagnostics;
using System.Diagnostics.Tracing;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gather.Models
{
    public class GatherContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<ApplicationUser> AspNetUsers { get; set; }
        public DbSet<EventUser> EventUsers { get; set; }
        public DbSet<EventActivity> EventActivities { get; set; }

        public DbSet<EventVendor> EventVendors { get; set; }
        public DbSet<EventItem> EventItems { get; set; }

        public DbSet<UserVendor> UserVendors { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }

        public DbSet<UserItem> UserItems { get; set; }

        public DbSet <VendorItem> VendorItems { get; set; }
        

      
        public GatherContext(DbContextOptions options) : base(options) { }
    }
}