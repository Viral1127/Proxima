using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proxima.Models;

namespace Proxima.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminDashboardController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public AdminDashboardController(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient
            {
                BaseAddress = new System.Uri(_configuration["WebApiBaseUrl"])
            };
        }
        public async Task<IActionResult> Index()
        {
            var dashboardData = new AdminDashboardData();

            try
            {
                var response = await _httpClient.GetAsync("api/AdminDashboard/GetAdminDashboardData");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    dashboardData = JsonConvert.DeserializeObject<AdminDashboardData>(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching dashboard data: " + ex.Message);
            }

            return View("Index", dashboardData ?? new AdminDashboardData());
        }
    }
}
