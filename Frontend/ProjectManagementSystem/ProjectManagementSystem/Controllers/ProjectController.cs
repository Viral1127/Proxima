using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Controllers
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



















        //public IActionResult ProjectList()
        //{
        //    var projects = new List<object>
        //{
        //    new { Name = "Copilot", Organization = "Pixer", StatusText = "On Schedule", StatusPercentage = 25, StatusType = "success" },
        //    new { Name = "TC Accounting", Organization = "Pixer Digital", StatusText = "At Risk", StatusPercentage = 65, StatusType = "warning" },
        //    new { Name = "Salescamp", Organization = "Pixer Digital", StatusText = "Behind Schedule", StatusPercentage = 90, StatusType = "danger" },
        //    new { Name = "Wedding Website", Organization = "hatchhouse digital", StatusText = "Not started yet", StatusPercentage = 0, StatusType = "neutral" },
        //    new { Name = "Teamcamp", Organization = "Pixer Digital", StatusText = "Behind Schedule", StatusPercentage = 90, StatusType = "danger" }
        //};

        //    return View(projects);
        //}

        //public IActionResult Kanban() {
        //    var kanbanData = new Dictionary<string, List<Dictionary<string, object>>>
        //    {
        //        {
        //            "Todo", new List<Dictionary<string, object>>
        //            {
        //                new Dictionary<string, object>
        //                {
        //                    { "Id", "t1" },
        //                    { "Title", "Landing page" },
        //                    { "Description", "Call Joan to discuss existing requirements" },
        //                    { "Tag", "UI" },
        //                    { "TimeAgo", "4d" },
        //                    { "Assignees", new List<string> { "https://example.com/assignee1.jpg", "https://example.com/assignee2.jpg" } }
        //                },
        //                new Dictionary<string, object>
        //                {
        //                    { "Id", "t2" },
        //                    { "Title", "Dashboard UI" },
        //                    { "Description", "Refine the layout for better UX" },
        //                    { "Tag", "Design" },
        //                    { "TimeAgo", "2d" },
        //                    { "HasFlag", true },
        //                    { "Assignees", new List<string> { "https://example.com/assignee3.jpg" } }
        //                }
        //            }
        //        },
        //        {
        //            "In Progress", new List<Dictionary<string, object>>
        //            {
        //                new Dictionary<string, object>
        //                {
        //                    { "Id", "t3" },
        //                    { "Title", "API Integration" },
        //                    { "Description", "Connect the UI with backend" },
        //                    { "Tag", "Development" },
        //                    { "TimeAgo", "Yesterday" },
        //                    { "HasFlag", true },
        //                    { "Assignees", new List<string> { "https://example.com/assignee4.jpg" } }
        //                }
        //            }
        //        },
        //        {
        //            "In Review", new List<Dictionary<string, object>>
        //            {
        //                new Dictionary<string, object>
        //                {
        //                    { "Id", "t4" },
        //                    { "Title", "Testing Phase" },
        //                    { "Description", "Run test cases for final deployment" },
        //                    { "Tag", "QA" },
        //                    { "TimeAgo", "5d" },
        //                    { "Assignees", new List<string> { "https://example.com/assignee5.jpg" } }
        //                }
        //            }
        //        }
        //    };

        //    ViewBag.KanbanData = kanbanData;
        //    return View();
        //}

        
        //    [HttpPost]
        //    public JsonResult ProjectAddEdit(ProjectModel model)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            // Save to database (dummy example)
        //            return Json(new { success = true, message = "Project created successfully!" });
        //        }
        //        return Json(new { success = false, message = "Invalid data." });
        //    }
    }
}
