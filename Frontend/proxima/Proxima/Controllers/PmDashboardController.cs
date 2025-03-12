using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proxima.Models;
using static Proxima.Models.PmDashboardModel;

namespace Proxima.Controllers
{
    //[Authorize(Roles = "ProjectManager")]
    public class PmDashboardController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        
        public PmDashboardController(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient
            {
                BaseAddress = new System.Uri(_configuration["WebApiBaseUrl"])
            };
        }
        public async Task<IActionResult> Index()
        {
            var pmDashboardData = new PmDashboardData();
            int UserID = int.Parse(User.FindFirst("UserID").Value);

            try
            {
                var response = await _httpClient.GetAsync($"api/PmDashboard/GetProjectManagerDashboardData/{UserID}");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    pmDashboardData = JsonConvert.DeserializeObject<PmDashboardData>(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching dashboard data: " + ex.Message);
            }

            return View("PmDashboard", pmDashboardData ?? new PmDashboardData());
        }
    }
}
