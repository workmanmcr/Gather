using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Gather.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gather.Controllers
{
  public class UsersController : Controller
  {
    private readonly GatherContext _db;

    public UsersController(GatherContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Users.ToList());
    }

    public ActionResult Details(int id)
    {
      User thisUser = _db.Users
          .Include(user => user.JoinUsers)
          .ThenInclude(join => join.Event)
          .FirstOrDefault(user => user.UserId == id);
      return View(thisUser);
    }
    
    [Authorize]
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(User user)
    {
      _db.Users.Add(user);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    [Authorize]
    public ActionResult AddEvent(int id)
    {
      User thisUser = _db.Users.FirstOrDefault(users => users.UserId == id);
      ViewBag.EventId = new SelectList(_db.Events, "EventId", "Name");
      return View(thisUser);
    }

    [HttpPost]
    public ActionResult AddEvent(User user, int eventId)
    {
      #nullable enable
      EventUser? joinUsers = _db.EventUsers.FirstOrDefault(join => (join.EventId == eventId && join.UserId == user.UserId));
      #nullable disable
      if (joinUsers == null && eventId != 0)
      {
        _db.EventUsers.Add(new EventUser() { EventId = eventId, UserId = user.UserId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = user.UserId });
    }
    
    [Authorize]
    public ActionResult Edit(int id)
    {
      User thisUser = _db.Users.FirstOrDefault(users => users.UserId == id);
      return View(thisUser);
    }

    [HttpPost]
    public ActionResult Edit(User user)
    {
      _db.Users.Update(user);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    [Authorize]
    public ActionResult Delete(int id)
    {
      User thisUser = _db.Users.FirstOrDefault(users => users.UserId == id);
      return View(thisUser);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      User thisUser = _db.Users.FirstOrDefault(users => users.UserId == id);
      _db.Users.Remove(thisUser);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    [Authorize]
    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      EventUser joinEntry = _db.EventUsers.FirstOrDefault(entry => entry.EventUserId == joinId);
      _db.EventUsers.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
