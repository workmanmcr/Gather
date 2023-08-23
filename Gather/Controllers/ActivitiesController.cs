using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Gather.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

#nullable disable
namespace Gather.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly GatherContext _db;

        public ActivitiesController(GatherContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Activity> model = _db.Activities.ToList();
            return View(model);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Activity activity)
        {
            _db.Activities.Add(activity);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Activity thisActivity = _db.Activities.Include(a => a.UserActivities).ThenInclude(join => join.User).FirstOrDefault(activity => activity.ActivityId == id);
            return View(thisActivity);
        }

        [Authorize]
        public ActionResult AddGuest(int id)
        {
            Activity thisActivity = _db.Activities.FirstOrDefault(activity => activity.ActivityId == id);
            ViewBag.ApplicationUserId = new SelectList(_db.Users, "ApplicationUserId");
            return View(thisActivity);
        }

        [HttpPost]
        public ActionResult AddGuest(Activity activity, int userId)
        {
#nullable enable
            UserActivity? joinEntity = _db.UserActivities.FirstOrDefault(join => (join.ActivityId == activity.ActivityId && join.ApplicationUserId == userId));
#nullable disable

            if (joinEntity == null && activity.ActivityId != 0)
            {
                _db.UserActivities.Add(new UserActivity() { ActivityId = activity.ActivityId, ApplicationUserId = userId });
                _db.SaveChanges();
            }
            return RedirectToAction("Details", new { id = activity.ActivityId });
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            Activity thisActivity = _db.Activities.FirstOrDefault(a => a.ActivityId == id);
            return View(thisActivity);
        }

        [HttpPost]
        public ActionResult Edit(Activity activity)
        {
            _db.Activities.Update(activity);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            Activity thisActivity = _db.Activities.FirstOrDefault(a => a.ActivityId == id);
            return View(thisActivity);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Activity thisActivity = _db.Activities.FirstOrDefault(a => a.ActivityId == id);
            _db.Activities.Remove(thisActivity);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}