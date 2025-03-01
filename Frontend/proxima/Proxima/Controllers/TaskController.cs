using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proxima.Models;

namespace Proxima.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly ApplicationDbContext _context;
        public TaskController(IConfiguration configuration, ApplicationDbContext context)
        {
            _configuration = configuration;
            _httpClient = new HttpClient
            {
                BaseAddress = new System.Uri(_configuration["WebApiBaseUrl"])
            };
            _context = context;
        }

        public async Task<ActionResult> TaskDetails(int id)
        {
            // Check if taskId is coming through
            Console.WriteLine($"Task ID: {id}");  // This will print to the server log

            var response = await _httpClient.GetAsync($"api/Task/{id}");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                var task = JsonConvert.DeserializeObject<TaskModel>(data);
                return View(task);
            }
            return View(new TaskModel());
        }

        [Authorize]
        public async Task<ActionResult> MyTasks()
        {
            var userId = User.FindFirst("UserID")?.Value;
            var response = await _httpClient.GetAsync($"api/Task/TasksByUserID/{userId}");

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                var tasks = JsonConvert.DeserializeObject<List<TaskModel>>(data); // Deserialize into List<TaskModel>
                return View(tasks);
            }

            return View(new List<TaskModel>()); // Return an empty list if API fails
        }


    }
}
