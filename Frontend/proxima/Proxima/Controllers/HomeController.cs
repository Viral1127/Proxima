using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proxima.Models;

namespace Proxima.Controllers
{
    public class HomeController : Controller
    {


        [Authorize]
        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "AdminDashboard");
            }
            else if (User.IsInRole("Project Manager"))
            {
                return RedirectToAction("Index", "PmDashboard");
            }
            else if (User.IsInRole("Team Member"))
            {
                return RedirectToAction("Index", "PmDashboard");
            }
            else
            {
                return View();
            }
        }
    }
}
