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
            return View();
        }
    }
}
