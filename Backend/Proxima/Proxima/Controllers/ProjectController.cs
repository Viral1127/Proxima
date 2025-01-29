using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proxima.Data;
using Proxima.Models;

namespace Proxima.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectRepository _projectRepository;

        public ProjectController(ProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        #region GetAllProjects

        [HttpGet]
        public IActionResult GetAllProjects()
        {
            if (!User.IsInRole("Admin"))
            {
                return StatusCode(500, "Only Admin can see all projects");
            }
            var projects = _projectRepository.GetProjects();
            return Ok(projects);

        }

        #endregion

        #region GetProjectByID

        [HttpGet("{projectID}")]
        public IActionResult GetProjectByID(int projectID)
        {
            
            var project = _projectRepository.GetProjectByID(projectID);
            if (project == null)
            {
                return NotFound(new { Message = "Given ProjectID not found" });
            }
            return Ok(project);
        }
        #endregion

        #region GetProjectByClientID
        [HttpGet("ProjectsByClientID/{clientID}")]
        public IActionResult GetProjectByClientID(int clientID)
        {
            var projects = _projectRepository.GetProjectByClientID(clientID);
            if (projects == null)
            {
                return NotFound(new { Message = "given ClientID not found" });
            }
            return Ok(projects);
        }
        #endregion

        #region CreateProject
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateProject(ProjectModel project)
        {

            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized(new { Message = "Please log in first to create a project." });
            }

            if (!User.IsInRole("Admin"))
            {
                //var response = new { Message = "You have no access to perform this action." };
                return StatusCode(500 , "You have no access to Create project");
            }

            if (project == null)
            {
                BadRequest();
            }

            bool isInserted = _projectRepository.CreateProject(project);
            if (isInserted)
            {
                return Ok(new { Message = "Project Created Successfully" });
            }
            return StatusCode(500, "An error occured while creating project");

        }
        #endregion

        #region UpdateProject

        [HttpPut("{projectID}")]

        public IActionResult UpdateProject(int projectID, [FromBody] ProjectModel project)
        {
            if(!(User.IsInRole("Admin") || User.IsInRole("Project Manager"))){
                return StatusCode(500, "Only Admin, Project Manager can Update project details.");
            }
            if (project == null || projectID != project.ProjectID)
            {
                return BadRequest();
            }
            var isUpdated = _projectRepository.UpdateProject(project);
            if (isUpdated)
            {
                return Ok(new { Message = "Project Updated succesfully" });
            }
            else
            {
                return StatusCode(500, "An error occured while updating Project");
            }
        }

        #endregion

        #region ArchiveProject
        [HttpDelete("ArchiveProject/{projectID}")]

        public IActionResult ArchiveProject(int projectID)
        {
            if (!(User.IsInRole("Admin")))
            {
                return StatusCode(500, "Only Admin can Delete Project");
            }
            var isArchived = _projectRepository.ArchiveProject(projectID);
            if (isArchived)
            {
                return Ok(new { Message = "Project Archived successfully" });
            }
            else
            {
                return NotFound(new { Message = "Project not found or Archive failed" });
            }
            return NoContent();
        }

        #endregion
    }
}
