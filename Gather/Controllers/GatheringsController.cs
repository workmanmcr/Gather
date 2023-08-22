using Microsoft.AspNetCore.Mvc;
using Gather.Models;
using Microsoft.AspNetCore.Authorization;

#nullable disable
namespace Gather.Controllers
{
    public class GatheringsController : Controller
    {
        private readonly GatherContext _db;

        public GatheringsController(GatherContext db)
        {
            _db = db;
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
            Gathering thisGathering = _db.Gatherings.FirstOrDefault(g => g.GatheringId == id);
            return View(thisGathering);
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
