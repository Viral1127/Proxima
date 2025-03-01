using Microsoft.AspNetCore.Mvc;
using Proxima.Models;

namespace Proxima.Controllers
{
    public class UserController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient
            {
                BaseAddress = new System.Uri(_configuration["WebApiBaseUrl"])
            };
        }
        public IActionResult UserList()
        {
            return View();
        }
    }
}
