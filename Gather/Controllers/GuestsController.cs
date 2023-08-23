using Gather.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gather.Controllers
{
  public class GuestsController : Controller
  {
    private readonly GatherContext _db;

        public GuestsController(GatherContext db)
        {
            _db = db;
        }
    public ActionResult Index()
    {
        List<ApplicationUser> model = _db.AspNetUsers.ToList();
        return View(model);
    }
  }
}