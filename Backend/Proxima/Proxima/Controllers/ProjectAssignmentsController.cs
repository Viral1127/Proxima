using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proxima.Data;
using Proxima.Models;

namespace Proxima.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectAssignmentsController : ControllerBase
    {
        private readonly ProjectAssignmentsRepository _projectAssignmentsRepository;

        public ProjectAssignmentsController(ProjectAssignmentsRepository projectAssignmentsRepository)
        {
            _projectAssignmentsRepository = projectAssignmentsRepository;
        }

        #region AssignUserToProject
        [HttpPost]
        public IActionResult AssignUserToProject([FromBody] ProjectAssignmentsModel projectAssignments)
        {
            if (User.IsInRole("Admin"))
            {
                return StatusCode(500, "Only Admin can assign project to user");
                
            }
            if (projectAssignments == null)
            {
                return BadRequest();
            }
            bool isInserted = _projectAssignmentsRepository.AssignUserToProject(projectAssignments);

            if (isInserted)
            {
                return Ok(new { Message = "Project Assigned succesfully" });
            }
            return StatusCode(500, "User already assigned with this project or An error occured while assigning project to user");
        }
        #endregion

        #region GetUserByProjectID

        [HttpGet("{projectID}")]
        public IActionResult GetUserByProjectID(int projectID)
        {
            if (!User.IsInRole("Admin"))
            {
                return StatusCode(500, "only Admin can see the list of users by ProjectID");
            }
            var users = _projectAssignmentsRepository.GetUserByProjectID(projectID);
            if (users == null)
            {
                NotFound();
            }
            return Ok(users);
        }

        #endregion
    }
}
