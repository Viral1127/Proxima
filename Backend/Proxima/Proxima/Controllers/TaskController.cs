using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proxima.Data;
using Proxima.Models;

namespace Proxima.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskRepository _taskRepository;

        public TaskController(TaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        #region GetTasks
        [HttpGet]
        public IActionResult GetTasks()
        {
            var tasks = _taskRepository.GetTasks();
            return Ok(tasks);
        }
        #endregion

        #region GetTaskByID
        [HttpGet("{taskID}")]
        public IActionResult GetTaskByID(int taskID)
        {
            var task = _taskRepository.GetTaskByID(taskID);
            if (task == null)
            {
                NotFound();
            }
            return Ok(task);
        }
        #endregion

        #region GetTasksByProjectID
        [HttpGet("TasksByProjectID/{projectID}")]
        public IActionResult GettasksByProjectID(int projectID)
        {
            var tasks = _taskRepository.GetTasksByProjectID(projectID);
            if (tasks == null)
            {
                NotFound();
            }
            return Ok(tasks);
        }
        #endregion

        #region AddTasks
        [HttpPost]
        public IActionResult CreateTasks([FromBody] TaskSaveModel tasks)
        {
            //if(!(User.IsInRole("Admin") || User.IsInRole("Project Manager")))
            //{
            //    return StatusCode(500, "You have no access to create task");
            //}
            if (tasks == null)
            {
                return BadRequest();
            }
            bool isInserted = _taskRepository.CreateTasks(tasks);

            if (isInserted)
            {
                return Ok(new { Message = "Task added succesfully" });
            }
            return StatusCode(500, "An error occured while creating task");
        }
        #endregion

        #region UpdateTask

        [HttpPut("{taskID}")]
        public IActionResult UpdateTask(int taskID, [FromBody] TaskModel tasks)
        {
            if (!(User.IsInRole("Admin") || User.IsInRole("Project Manager")))
            {
                return StatusCode(500, "You have no access to Update task");
            }
            if (tasks == null || taskID != tasks.TaskID)
            {
                return BadRequest();
            }
            var isUpdated = _taskRepository.UpdateTasks(tasks);
            if (isUpdated)
            {
                return Ok(new { Message = "Task Updated succesfully" });
            }
            else
            {
                return StatusCode(500, "An error occured while updating Task");
            }
        }

        #endregion

        #region Update TaskStatus

        [HttpPut("UpdateStatus/{taskID}")]
        public IActionResult UpdateTaskStatus(int taskID, [FromBody] TaskStatusModel taskStatus)
        {
            //if (!(User.IsInRole("Admin") || User.IsInRole("Project Manager")))
            //{
            //    return StatusCode(500, "You have no access to Update task");
            //}
            if (taskStatus == null || taskID != taskStatus.TaskID)
            {
                return BadRequest();
            }
            var isUpdated = _taskRepository.UpdateTaskStatus(taskStatus);
            if (isUpdated)
            {
                return Ok(new { Message = "Task Status Updated succesfully" });
            }
            else
            {
                return StatusCode(500, "An error occured while updating Task status");
            }
        }

        #endregion

        #region DeleteTask
        [HttpDelete("{taskID}")]

        public IActionResult DeleteTask(int taskID)
        {
            //if (!(User.IsInRole("Admin") || User.IsInRole("Project Manager")))
            //{
            //    return StatusCode(500, "You have no access to delete task");
            //}
            var isDeleted = _taskRepository.DeleteTasks(taskID);
            if (isDeleted)
            {
                return Ok(new { Message = "Task deleted successfully" });
            }
            else
            {
                return NotFound(new { Message = "Task not found or Deletion failed" });
            }
            return NoContent();
        }
        #endregion
    }
}
