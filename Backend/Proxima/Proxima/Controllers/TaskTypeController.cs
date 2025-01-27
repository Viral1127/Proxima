using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proxima.Data;
using Proxima.Models;

namespace Proxima.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskTypeController : ControllerBase
    {
        private readonly TaskTypeRepository _taskTypeRepository;

        public TaskTypeController(TaskTypeRepository taskTypeRepository)
        {
            _taskTypeRepository = taskTypeRepository;
        }

        #region GetTaskTypes
        [HttpGet]
        public IActionResult GetMilestones()
        {
            var taskTypes = _taskTypeRepository.GetTaskTypes();
            return Ok(taskTypes);
        }
        #endregion

        #region AddTaskTypes
        [HttpPost]
        public IActionResult AddTaskTypes([FromBody] TaskTypeModel taskType)
        {
            if (taskType == null)
            {
                return BadRequest();
            }
            bool isInserted = _taskTypeRepository.AddTaskType(taskType);

            if (isInserted)
            {
                return Ok(new { Message = "TaskType added succesfully" });
            }
            return StatusCode(500, "An error occured while creating TaskType");
        }
        #endregion

        #region UpdateMilestone

        [HttpPut("{taskTypeID}")]
        public IActionResult UpdateMilestone(int taskTypeID, [FromBody] TaskTypeModel taskType)
        {
            if (taskType == null || taskTypeID != taskType.TaskTypeID)
            {
                return BadRequest();
            }
            var isUpdated = _taskTypeRepository.UpdateTaskType(taskType);
            if (isUpdated)
            {
                return Ok(new { Message = "TaskType  Updated succesfully" });
            }
            else
            {
                return StatusCode(500, "An error occured while updating TaskType");
            }
        }

        #endregion

        #region DeleteTaskType
        [HttpDelete("{taskTypeID}")]

        public IActionResult DeleteMilestone(int taskTypeID)
        {
            var isDeleted = _taskTypeRepository.DeleteTaskType(taskTypeID);
            if (isDeleted)
            {
                return Ok(new { Message = "TaskType Deleted successfully" });
            }
            else
            {
                return NotFound(new { Message = "TaskType not found or Deletion failed" });
            }
            return NoContent();
        }
        #endregion
    }
}
