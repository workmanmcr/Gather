using Microsoft.AspNetCore.Mvc;
using Gather.Models;
using Microsoft.AspNetCore.Authorization;

#nullable disable
namespace Gather.Controllers
{
    public class GuestItemsController : Controller
    {
        private readonly GatherContext _db;

        public GuestItemsController(GatherContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<GuestItem> model = _db.GuestItems.ToList();
            return View(model);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GuestItem i)
        {
            _db.GuestItems.Add(i);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            GuestItem thisGuestItem = _db.GuestItems.FirstOrDefault(e => e.GuestItemId == id);
            return View(thisGuestItem);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            GuestItem thisGuestItem = _db.GuestItems.FirstOrDefault(a => a.GuestItemId == id);
            return View(thisGuestItem);
        }

        [HttpPost]
        public ActionResult Edit(GuestItem e)
        {
            _db.GuestItems.Update(e);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            GuestItem thisGuestItem = _db.GuestItems.FirstOrDefault(a => a.GuestItemId == id);
            return View(thisGuestItem);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            GuestItem thisGuestItem = _db.GuestItems.FirstOrDefault(a => a.GuestItemId == id);
            _db.GuestItems.Remove(thisGuestItem);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}