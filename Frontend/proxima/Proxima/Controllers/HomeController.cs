using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Proxima.Models;

namespace Proxima.Controllers
{
    public class HomeController : Controller
    {
       

       
        public IActionResult Index()
        {
            return View();
        }
    }
}
