using Microsoft.AspNetCore.Mvc;
using Gather.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gather.Controllers
{
  public class VendorsController : Controller
  {
    private readonly GatherContext _db;

    public VendorsController(GatherContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Vendor> model = _db.Vendors.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.GatheringId = new SelectList(_db.Gatherings, "GatheringId", "Title");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Vendor vendor, int GatheringId)
    {
      _db.Vendors.Add(vendor);
      _db.SaveChanges();
      if (GatheringId != 0)
      {
        _db.GatheringVendors.Add(new GatheringVendor() { GatheringId = GatheringId, VendorId = vendor.VendorId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisVendor = _db.Vendors
          .Include(vendor => vendor.GatheringVendors)
              .ThenInclude(join => join.Gathering)
          .FirstOrDefault(vendor => vendor.VendorId == id);

      return View(thisVendor);
    }


    public ActionResult Edit(int id)
    {
      ViewBag.GatheringId = new SelectList(_db.Gatherings, "GatheringId", "Title");
      Vendor thisVendor = _db.Vendors.FirstOrDefault(vendor => vendor.VendorId == id);
      return View(thisVendor);
    }

    [HttpPost]
    public ActionResult Edit(Vendor vendor)
    {
      _db.Entry(vendor).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = vendor.VendorId });
    }

    public ActionResult AddItem(int id)
    {
      var thisVendor = _db.Vendors.FirstOrDefault(vendor => vendor.VendorId == id);
      ViewBag.ItemId = new SelectList(_db.Items, "ItemId", "ItemName");
      return View(thisVendor);
    }

    [HttpPost]
    public ActionResult AddItem(Vendor vendor, int itemId)
    {
#nullable enable
      VendorItem? joinEntity = _db.VendorItems.FirstOrDefault(join => (join.ItemId == itemId && join.VendorId == vendor.VendorId));
#nullable disable
      if (joinEntity == null && itemId != 0)
      {
        _db.VendorItems.Add(new VendorItem() { ItemId = itemId, VendorId = vendor.VendorId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = vendor.VendorId });
    }


    public ActionResult Delete(int id)
    {
      Vendor thisVendor = _db.Vendors.FirstOrDefault(vendor => vendor.VendorId == id);
      return View(thisVendor);
    }

    [HttpPost, ActionName("Delete")]

    public ActionResult DeleteConfirmed(int id)
    {
      Vendor thisVendor = _db.Vendors.FirstOrDefault(vendor => vendor.VendorId == id);
      _db.Vendors.Remove(thisVendor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]

    public ActionResult DeleteItem(int joinId)
    {
      VendorItem joinEntry = _db.VendorItems.FirstOrDefault(entry => entry.ItemId == joinId);
      _db.VendorItems.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = joinEntry.VendorId });
    }

  }
}