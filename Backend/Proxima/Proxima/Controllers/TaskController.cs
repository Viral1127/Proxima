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
        public IActionResult CreateTasks([FromBody] TaskModel tasks)
        {
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

        #region DeleteTask
        [HttpDelete("{taskID}")]

        public IActionResult DeleteTask(int taskID)
        {
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
