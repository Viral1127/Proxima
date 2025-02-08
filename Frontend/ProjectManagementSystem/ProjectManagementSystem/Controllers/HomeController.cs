using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        
        public IActionResult Index()
        {
            return View();
        }

     
    }
}
