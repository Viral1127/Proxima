using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PMS.Models;

namespace PMS.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
