using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proxima.Data;
using Proxima.Models;

namespace Proxima.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskAssignmentController : ControllerBase
    {
        private readonly TaskAssignmentRepository _taskAssignmentRepository;

        public TaskAssignmentController(TaskAssignmentRepository taskAssignmentsRepository)
        {
            _taskAssignmentRepository = taskAssignmentsRepository;
        }

        #region AssignTaskToUser
        [HttpPost]
        public IActionResult AssignTaskToUser([FromBody] TaskAssignmentSave taskAssignments)
        {
            //if (!(User.IsInRole("Admin") || User.IsInRole("Project Manager")))
            //{
            //    return StatusCode(500, "Only Admin and Project Manager can assign task to user");
            //}
            if (taskAssignments == null)
            {
                return BadRequest();
            }
            bool isInserted = _taskAssignmentRepository.AssignTaskToUser(taskAssignments);

            if (isInserted)
            {
                return Ok(new { Message = "Task Assigned succesfully" });
            }
            return StatusCode(500, "An error occured while assigning project to user");
        }
        #endregion

        #region GetTaskAssignmentsByTaskID

        [HttpGet("{taskID}")]
        public IActionResult GetTaskAssignmentsByTaskID(int taskID)
        {
            var assignments = _taskAssignmentRepository.GetTaskAssignmentsByTaskID(taskID);
            if (assignments == null)
            {
                NotFound();
            }
            return Ok(assignments);
        }

        #endregion

        #region GetTaskAssignmentsByUser

        [HttpGet("TaskAssignmentByUserID/{userID}")]
        public IActionResult GetTaskAssignmentsByUserID(int userID)
        {
            var assignments = _taskAssignmentRepository.GetTaskAssignmentsByUserID(userID);
            if (assignments == null)
            {
                NotFound();
            }
            return Ok(assignments);
        }

        #endregion

        #region RemoveUserFromTask
        [HttpPost("removeUserFromTask")]
        public IActionResult DeleteTaskAssignment([FromBody] TaskAssignmentSave taskAssignments)
        {
            //if (!(User.IsInRole("Admin") || User.IsInRole("Project Manager")))
            //{
            //    return StatusCode(500, "You have not access to Remove task from user");
            //}
            var isDeleted = _taskAssignmentRepository.DeleteTaskAssignments(taskAssignments.TaskID, taskAssignments.UserID);
            if (isDeleted)
            {
                return Ok("User removed from task");
            }
            else
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
