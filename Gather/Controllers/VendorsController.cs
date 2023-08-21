using Microsoft.AspNetCore.Mvc;
using Gather.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gather.Controllers
{
  public class VendorController : Controller
  {
    private readonly GatherContext _db;

    public VendorController(GatherContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      IEnumerable<Vendor> sortedVendors = _db.Vendors.OrderBy(machine => machine.VendorName);
      return View(sortedVendors.ToList());
    }

    public ActionResult Create()
    {
        ViewBag.EventId = new SelectList(_db.Events, "EventId", "Title");
    return View();
    }

    [HttpPost]
    public ActionResult Create(Vendor vendor, int EventId)
    {
      _db.Vendors.Add(vendor);
      _db.SaveChanges();
      if (EventId !=0)
      {
        _db.EventVendors.Add(new EventVendor() { EventId = EventId, VendorId = vendor.VendorId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  public ActionResult Details(int id)
{
    var thisVendor = _db.Vendors
        .Include(vendor => vendor.JoinEntities)
            .ThenInclude(join => join.Event) 
        .FirstOrDefault(vendor => vendor.VendorId == id);

    return View(thisVendor);
}


    public ActionResult Edit(int id)
    {
      ViewBag.EventId = new SelectList(_db.Events, "EventId", "Title");
      Vendor thisVendor = _db.Vendors.FirstOrDefault(vendor => vendor.VendorId == id);
      return View(thisVendor);
    }

    [HttpPost]
    public ActionResult Edit (Vendor vendor)
    {
      _db.Entry(vendor).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new {id = vendor.VendorId });
    }

     public ActionResult AddItem(int id)
    {
      var thisVendor = _db.Vendors.FirstOrDefault(vendor => vendor.VendorId == id);
      ViewBag.ItemId = new SelectList(_db.Items, "ItemId", "ItemName");
      return View(thisVendor);
    }
    
    [HttpPost]
    public ActionResult AddItem(Vendor Vendor, int ItemId)
    {
      if (ItemId != 0)
      {
        _db.VendorItems.Add(new VendorItem() { ItemId = ItemId, VendorId = vendor.VendorId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
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
      var joinEntry = _db.VendorItems.FirstOrDefault(entry => entry.VendorItemId == joinId);
      _db.VendorItems.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = joinEntry.VendorId });
    }

  }
}