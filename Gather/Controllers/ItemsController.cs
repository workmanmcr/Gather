using Microsoft.AspNetCore.Mvc;
using Gather.Models;
using Microsoft.AspNetCore.Authorization;

#nullable disable
namespace Gather.Controllers
{
    public class ItemsController : Controller
    {
        private readonly GatherContext _db;

        public ItemsController(GatherContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Item> model = _db.Items.ToList();
            return View(model);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Item i)
        {
            _db.Items.Add(i);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Item thisItem = _db.Items.FirstOrDefault(e => e.ItemId == id);
            return View(thisItem);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            Item thisItem = _db.Items.FirstOrDefault(a => a.ItemId == id);
            return View(thisItem);
        }

        [HttpPost]
        public ActionResult Edit(Item e)
        {
            _db.Items.Update(e);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            Item thisItem = _db.Items.FirstOrDefault(a => a.ItemId == id);
            return View(thisItem);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Item thisItem = _db.Items.FirstOrDefault(a => a.ItemId == id);
            _db.Items.Remove(thisItem);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}