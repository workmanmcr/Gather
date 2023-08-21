using Microsoft.AspNetCore.Mvc;
using Gather.Models;
using Microsoft.AspNetCore.Authorization;

#nullable disable
namespace Gather.Controllers
{
    public class EventsController : Controller
    {
        private readonly GatherContext _db;

        public EventsController(GatherContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Event> model = _db.Events.ToList();
            return View(model);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Event e)
        {
            _db.Events.Add(e);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Event thisEvent = _db.Events.FirstOrDefault(e => e.EventId == id);
            return View(thisEvent);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            Event thisEvent = _db.Events.FirstOrDefault(a => a.EventId == id);
            return View(thisEvent);
        }

        [HttpPost]
        public ActionResult Edit(Event e)
        {
            _db.Events.Update(e);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            Event thisEvent = _db.Events.FirstOrDefault(a => a.EventId == id);
            return View(thisEvent);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Event thisEvent = _db.Events.FirstOrDefault(a => a.EventId == id);
            _db.Events.Remove(thisEvent);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}