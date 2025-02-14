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
        public IActionResult AssignUserToProject([FromBody] ProjectAssignmentSave projectAssignments)
        {
            //if (User.IsInRole("Admin"))
            //{
            //    return StatusCode(500, "Only Admin can assign project to user");
                
            //}
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
            //if (!User.IsInRole("Admin"))
            //{
            //    return StatusCode(500, "only Admin can see the list of users by ProjectID");
            //}
            var users = _projectAssignmentsRepository.GetUserByProjectID(projectID);
            if (users == null)
            {
                NotFound();
            }
            return Ok(users);
        }

        #endregion

        #region RemoveTaskFromUser
        [HttpPost("removeUserFromProject")]
        public IActionResult DeleteTaskAssignment([FromBody] ProjectAssignmentSave projectAssignments)
        {
            //if (!(User.IsInRole("Admin") || User.IsInRole("Project Manager")))
            //{
            //    return StatusCode(500, "You have not access to Remove task from user");
            //}
            var isDeleted = _projectAssignmentsRepository.RemoveUser(projectAssignments.ProjectID , projectAssignments.UserID);
            if (isDeleted)
            {
                return Ok("User removed from Project    ");
            }
            else
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
