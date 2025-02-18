using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PMS.Models;

namespace PMS.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        public ProjectController(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient
            {
                BaseAddress = new System.Uri(_configuration["WebApiBaseUrl"])
            };
        }

        public async Task<IActionResult> ProjectList()
        {
            var response = await _httpClient.GetAsync("api/Project");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var projects = JsonConvert.DeserializeObject<List<ProjectModel>>(data);
                return View(projects);
            }
            return View(new List<ProjectModel>());
        }
    }
}
