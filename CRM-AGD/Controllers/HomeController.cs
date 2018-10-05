using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRM_AGD.Models;

namespace CRM_AGD.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      ChangeSubMenu(Enum.Module.None);
      return View();
    }

    public IActionResult About()
    {
      ChangeSubMenu(Enum.Module.None);
      ViewData["Message"] = "Your application description page.";

      return View();
    }

    public IActionResult Contact()
    {
      ChangeSubMenu(Enum.Module.None);
      ViewData["Message"] = "Your contact page.";

      return View();
    }

    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult ChangeSubMenu(Enum.Module module)
    {
      StaticValues.CheckModule = module;
      return View();
    }
  }
}
