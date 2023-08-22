using Microsoft.AspNetCore.Mvc;
using Gather.Models;
using Microsoft.AspNetCore.Authorization;

#nullable disable
namespace Gather.Controllers
{
    public class VendorItemsController : Controller
    {
        private readonly GatherContext _db;

        public VendorItemsController(GatherContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<VendorItem> model = _db.VendorItems.ToList();
            return View(model);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(VendorItem i)
        {
            _db.VendorItems.Add(i);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            VendorItem thisVendorItem = _db.VendorItems.FirstOrDefault(e => e.VendorItemId == id);
            return View(thisVendorItem);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            VendorItem thisVendorItem = _db.VendorItems.FirstOrDefault(a => a.VendorItemId == id);
            return View(thisVendorItem);
        }

        [HttpPost]
        public ActionResult Edit(VendorItem e)
        {
            _db.VendorItems.Update(e);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            VendorItem thisVendorItem = _db.VendorItems.FirstOrDefault(a => a.VendorItemId == id);
            return View(thisVendorItem);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            VendorItem thisVendorItem = _db.VendorItems.FirstOrDefault(a => a.VendorItemId == id);
            _db.VendorItems.Remove(thisVendorItem);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}