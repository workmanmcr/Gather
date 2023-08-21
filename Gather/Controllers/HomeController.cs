using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Gather.Models;

namespace Gather.Controllers;

public class HomeController : Controller
{


   

    public IActionResult Index()
    {
        return View();
    }

    }