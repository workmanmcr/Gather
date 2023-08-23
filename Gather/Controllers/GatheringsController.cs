using Microsoft.AspNetCore.Mvc;
using Gather.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;



#nullable disable
namespace Gather.Controllers
{
    public class GatheringsController : Controller
    {
        private readonly GatherContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public GatheringsController(UserManager<ApplicationUser> userManager, GatherContext db)
        {
            _db = db;
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            List<Gathering> model = _db.Gatherings.ToList();
            return View(model);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Gathering g)
        {
            _db.Gatherings.Add(g);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Gathering thisGathering = _db.Gatherings.Include(gathering => gathering.GatheringUsers).ThenInclude(join => join.User).Include(gathering => gathering.GatheringVendors).ThenInclude(join => join.Vendor).Include(gathering => gathering.GatheringItems).ThenInclude(join => join.Item).FirstOrDefault(g => g.GatheringId == id);
            return View(thisGathering);
        }
        [Authorize]
        public ActionResult AddGuest(int id)
        {
            Gathering thisGathering = _db.Gatherings.FirstOrDefault(gathering => gathering.GatheringId == id);
            ViewBag.ApplicationUserId = new SelectList(_db.Users, "ApplicationUserId");
            return View(thisGathering);
        }

        [HttpPost]
        public ActionResult AddGuest(Gathering gathering, int userId)
        {
#nullable enable
            GatheringUser? joinEntity = _db.GatheringUsers.FirstOrDefault(join => (join.GatheringId == gathering.GatheringId && join.ApplicationUserId == userId));
#nullable disable

            if (joinEntity == null && gathering.GatheringId != 0)
            {
                _db.GatheringUsers.Add(new GatheringUser() { GatheringId = gathering.GatheringId, ApplicationUserId = userId });
                _db.SaveChanges();
            }
            return RedirectToAction("Details", new { id = gathering.GatheringId });
        }

        [Authorize]
        [HttpPost]
        public ActionResult RemoveGuest(int joinId)
        {
            GatheringUser joinEntry = _db.GatheringUsers.FirstOrDefault(entry => entry.GatheringUserId == joinId);
            _db.GatheringUsers.Remove(joinEntry);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult AddVendor(int id)
        {
            Gathering thisGathering = _db.Gatherings.FirstOrDefault(gathering => gathering.GatheringId == id);
            ViewBag.VendorId = new SelectList(_db.Vendors, "VendorId", "VendorName");
            return View(thisGathering);
        }

        [HttpPost]
        public ActionResult AddVendor(Gathering gathering, int vendorId)
        {
#nullable enable
            GatheringVendor? joinEntity = _db.GatheringVendors.FirstOrDefault(join => (join.GatheringId == gathering.GatheringId && join.VendorId == vendorId));
#nullable disable

            if (joinEntity == null && gathering.GatheringId != 0)
            {
                _db.GatheringVendors.Add(new GatheringVendor() { GatheringId = gathering.GatheringId, VendorId = vendorId });
                _db.SaveChanges();
            }
            return RedirectToAction("Details", new { id = gathering.GatheringId });
        }

        [Authorize]
        [HttpPost]
        public ActionResult RemoveVendor(int joinId)
        {
            GatheringVendor joinEntry = _db.GatheringVendors.FirstOrDefault(entry => entry.GatheringVendorId == joinId);
            _db.GatheringVendors.Remove(joinEntry);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult AddItem(int id)
        {
            Gathering thisGathering = _db.Gatherings.FirstOrDefault(gathering => gathering.GatheringId == id);
            ViewBag.ItemId = new SelectList(_db.Items, "ItemId", "ItemName");
            return View(thisGathering);
        }

        [HttpPost]
        public ActionResult AddItem(Gathering gathering, int itemId)
        {
#nullable enable
            GatheringItem? joinEntity = _db.GatheringItems.FirstOrDefault(join => (join.ItemId == itemId && join.GatheringId == gathering.GatheringId));
#nullable disable
            if (joinEntity == null && itemId != 0)
            {
                _db.GatheringItems.Add(new GatheringItem() { ItemId = itemId, GatheringId = gathering.GatheringId });
                _db.SaveChanges();
            }
            return RedirectToAction("Details", new { id = gathering.GatheringId });
        }

        [Authorize]
        public ActionResult AddActivity(int id)
        {
            Gathering thisGathering = _db.Gatherings.FirstOrDefault(gathering => gathering.GatheringId == id);
            ViewBag.ActivityId = new SelectList(_db.Activities, "ActivityId", "Name");
            return View(thisGathering);
        }

        [HttpPost]
        public ActionResult AddActivity(Gathering gathering, int activityId)
        {
#nullable enable
            GatheringActivity? joinEntity = _db.GatheringActivities.FirstOrDefault(join => (join.ActivityId == activityId && join.GatheringId == gathering.GatheringId));
#nullable disable
            if (joinEntity == null && activityId != 0)
            {
                _db.GatheringActivities.Add(new GatheringActivity() { ActivityId = activityId, GatheringId = gathering.GatheringId });
                _db.SaveChanges();
            }
            return RedirectToAction("Details", new { id = gathering.GatheringId });
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            Gathering thisGathering = _db.Gatherings.FirstOrDefault(a => a.GatheringId == id);
            return View(thisGathering);
        }

        [HttpPost]
        public ActionResult Edit(Gathering g)
        {
            _db.Gatherings.Update(g);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            Gathering thisGathering = _db.Gatherings.FirstOrDefault(a => a.GatheringId == id);
            return View(thisGathering);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Gathering thisGathering = _db.Gatherings.FirstOrDefault(a => a.GatheringId == id);
            _db.Gatherings.Remove(thisGathering);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
