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
        public IActionResult AssignTaskToUser([FromBody] TaskAssignmentModel taskAssignments)
        {
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

        #region RemoveTaskFromUser
        [HttpDelete("{assignmentID}")]
        public IActionResult DeleteTaskAssignment(int assignmentID)
        { 
            var isDeleted = _taskAssignmentRepository.DeleteTaskAssignments(assignmentID);
            if (isDeleted)
            {
                return Ok("Task removed from user");
            }
            else
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
