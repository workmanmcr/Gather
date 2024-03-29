using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Gather.Models;
using System.Threading.Tasks;
using Gather.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gather.Controllers
{
  public class AccountController : Controller
  {
    private readonly GatherContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, GatherContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
    }

    public ActionResult Index()
    {
      return View();
    }

    public IActionResult Register()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Register(RegisterViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }
      else
      {
        ApplicationUser user = new ApplicationUser { UserName = model.Email };
        IdentityResult result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
          await _signInManager.SignInAsync(user, isPersistent: true);
          return RedirectToAction("Index");
        }
        else
        {
          foreach (IdentityError error in result.Errors)
          {
            ModelState.AddModelError("", error.Description);
          }
          return View(model);
        }

      }
    }
    public ActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Login(LoginViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }
      else
      {
        Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
        if (result.Succeeded)
        {
          return RedirectToAction("Index");
        }
        else
        {
          ModelState.AddModelError("", "There is something wrong with your email or username. Please try again.");
          return View(model);
        }
      }
    }
    [HttpPost]
    public async Task<ActionResult> LogOff()
    {
      await _signInManager.SignOutAsync();
      return RedirectToAction("Index");
    }

    public ActionResult AddItem(string id)
    {
      ApplicationUser thisUser = _db.AspNetUsers.FirstOrDefault(user => user.Id == id);
      ViewBag.ItemId = new SelectList(_db.Items, "ItemId", "ItemName");
      return View(thisUser);
    }

    [HttpPost]
    public ActionResult AddItem(ApplicationUser user, int itemId)
    {
#nullable enable
      GuestItem? joinEntity = _db.GuestItems.FirstOrDefault(join => join.ItemId == itemId && join.UserId == user.Id);
#nullable disable
      if (joinEntity == null && itemId != 0)
      {
        _db.GuestItems.Add(new GuestItem() { ItemId = itemId, UserId = user.Id });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }
  }
}