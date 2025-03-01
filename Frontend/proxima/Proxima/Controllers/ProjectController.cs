using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Proxima.Models;

namespace Proxima.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly ApplicationDbContext _context;
        public ProjectController(IConfiguration configuration,ApplicationDbContext context)
        {
            _configuration = configuration;
            _httpClient = new HttpClient
            {
                BaseAddress = new System.Uri(_configuration["WebApiBaseUrl"])
            };
            _context = context;
        }

        public async Task<IActionResult> ProjectList()
        {

            //var response = await _httpClient.GetAsync("api/Project");
            //if (response.IsSuccessStatusCode)
            //{
            //    var data = await response.Content.ReadAsStringAsync();
            //    var projects = JsonConvert.DeserializeObject<List<ProjectModel>>(data);
            //    return View(projects);
            //}
            //return View(new List<ProjectModel>());
            var projects = await _context.Projects.ToListAsync();
            return View(projects);
        }

        [HttpPost]
        public async Task<JsonResult> SaveProject([FromBody] ProjectSave project)
        {
            HttpResponseMessage response;
            
            if (project.ProjectID > 0)
            {
                var jsonContent = JsonConvert.SerializeObject(project);
                var content = new StringContent(jsonContent , Encoding.UTF8, "application/json");
                response = await _httpClient.PutAsync($"api/Project/{project.ProjectID}", content);
            }
            else
            {
                var jsonContent = JsonConvert.SerializeObject(project);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                response = await _httpClient.PostAsync($"api/Project", content);
            }
            return Json(response.IsSuccessStatusCode);
        }

        public async Task<ActionResult> ProjectDetails(int id)
        {
            var projectResponse = await _httpClient.GetAsync($"api/Project/{id}");
            var taskResponse = await _httpClient.GetAsync($"api/Task/TasksByProjectID/{id}");
            var milestoneResponse = await _httpClient.GetAsync($"api/Milestone/MilestonesByProjectID/{id}");
            var response = await _httpClient.GetAsync($"api/ProjectAttachment/AttachmentByProjectID/{id}");

            var viewModel = new ProjectDetailsViewModel();
            if (projectResponse.IsSuccessStatusCode)
            {
                string projectData = await projectResponse.Content.ReadAsStringAsync();
                viewModel.Project = JsonConvert.DeserializeObject<ProjectModel>(projectData);
            }
            if (taskResponse.IsSuccessStatusCode)
                {
                    string taskData = await taskResponse.Content.ReadAsStringAsync();
                    viewModel.Tasks = JsonConvert.DeserializeObject<List<TaskModel>>(taskData);
                }
            if (milestoneResponse.IsSuccessStatusCode)
            {
                string milestoneData = await milestoneResponse.Content.ReadAsStringAsync();
                viewModel.Milestones = JsonConvert.DeserializeObject<List<MilestoneModel>>(milestoneData);
            }
            if(response.IsSuccessStatusCode)
            {
                string attachmentData = await response.Content.ReadAsStringAsync();
                viewModel.Attachments = JsonConvert.DeserializeObject<List<ProjectAttachmentModel>>(attachmentData);
            }
            return View(viewModel);
        }

        public async Task<ActionResult>  ProjectOverview(int id)
        {
            var response = await _httpClient.GetAsync($"api/Project/{id}");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                var project = JsonConvert.DeserializeObject<ProjectModel>(data);
                return PartialView("_ProjectOverview", project);
            }
            return PartialView("_ProjectOverview",new ProjectModel());
        }
        public async Task<ActionResult> ProjectTasks(int id)
        {
            var response = await _httpClient.GetAsync($"api/Task/TasksByProjectID/{id}");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                var tasks = JsonConvert.DeserializeObject<List<TaskModel>>(data);
                return PartialView("_ProjectTasks", tasks); 
            }
            return PartialView("_ProjectTasks", new List<TaskModel>());
        }

        public async Task<ActionResult> ProjectMilestones(int id)
        {
            var response = await _httpClient.GetAsync($"api/Milestones/MilestonesByProjectID/{id}");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                var milestones = JsonConvert.DeserializeObject<List<MilestoneModel>>(data);
                return PartialView("_ProjectMilestones", milestones);
            }
            return PartialView("_ProjectMilestones", new List<MilestoneModel>());
        }

        public IActionResult TaskDetails()
        {
            return View();
        }

        public async Task<IActionResult> ProjectFiles(int id)
        {
            var response = await _httpClient.GetAsync($"api/ProjectAttachment/AttachmentByProjectID/{id}");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                var files = JsonConvert.DeserializeObject<List<ProjectAttachmentModel>>(data);
                return PartialView("_ProjectFiles", files);
            }
            return PartialView("_ProjectFiles", new List<ProjectAttachmentModel>());
        }

        //public IActionResult ProjectFiles()
        //{
        //    return PartialView("_ProjectFiles");
        //}

    }
}
