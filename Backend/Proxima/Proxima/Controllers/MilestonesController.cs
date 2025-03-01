using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proxima.Data;
using Proxima.Models;

namespace Proxima.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class MilestonesController : ControllerBase
    {
        private readonly MilestonesRepository _milestonesRepository;

        public MilestonesController(MilestonesRepository milestoneRepository)
        {
            _milestonesRepository = milestoneRepository;
        }

        #region GetMilestones
        [HttpGet]
        public IActionResult GetMilestones()
        {
            var milestones = _milestonesRepository.GetMilestones();
            return Ok(milestones);
        }
        #endregion

        #region GetMilestoneByID
        [HttpGet("{milestoneID}")]
        public IActionResult GetMilestoneByID(int milestoneID)
        {
            var milestone = _milestonesRepository.GetMilestoneByID(milestoneID);
            if (milestone == null)
            {
                NotFound();
            }
            return Ok(milestone);
        }
        #endregion

        #region GetMilestonesByProjectID
        [HttpGet("MilestonesByProjectID/{projectID}")]
        public IActionResult GetMilestonesByProjectID(int projectID)
        {
            var milestone = _milestonesRepository.GetMilestonesByProjectID(projectID);
            if (milestone == null)
            {
                NotFound();
            }
            return Ok(milestone);
        }
        #endregion

        #region AddMilestones
        [HttpPost]
        public IActionResult CreateMilestones([FromBody] MilestoneSaveModel milestones)
        {
            //if(!(User.IsInRole("Admin") || User.IsInRole("Project Manager")))
            //{
            //    return StatusCode(500, "You have not access to create project's milestone");
            //}
            if (milestones == null)
            {
                return BadRequest();
            }
            bool isInserted = _milestonesRepository.CreateMilestones(milestones);

            if (isInserted)
            {
                return Ok(new { Message = "Milestone added succesfully" });
            }
            return StatusCode(500, "An error occured while creating milestone");
        }
        #endregion

        #region UpdateMilestone

        [HttpPut("{milestoneID}")]
        public IActionResult UpdateMilestone(int milestoneID, [FromBody] MilestonesModel milestones)
        {
            if (!(User.IsInRole("Admin") || User.IsInRole("Project Manager")))
            {
                return StatusCode(500, "You have not access to update project's milestone");
            }
            if (milestones == null || milestoneID != milestones.MilestoneID)
            {
                return BadRequest();
            }
            var isUpdated = _milestonesRepository.UpdateMilestones(milestones);
            if (isUpdated)
            {
                return Ok(new { Message = "Milestone Updated succesfully" });
            }
            else
            {
                return StatusCode(500, "An error occured while updating Milestone");
            }
        }

        #endregion

        #region UpdateMilestone Status

        [HttpPut("UpdateMilestoneStatus/{milestoneID}")]
        public IActionResult UpdateMilestoneStatus(int milestoneID, [FromBody] MilestonesStatusModel milestoneStatus)
        {
            //if (!(User.IsInRole("Admin") || User.IsInRole("Project Manager")))
            //{
            //    return StatusCode(500, "You have not access to update project's milestone");
            //}
            if (milestoneStatus == null || milestoneID != milestoneStatus.MilestoneID)
            {
                return BadRequest();
            }
            var isUpdated = _milestonesRepository.UpdateMilestoneStatus(milestoneStatus);
            if (isUpdated)
            {
                return Ok(new { Message = "Milestone Status Updated succesfully" });
            }
            else
            {
                return StatusCode(500, "An error occured while updating Milestone");
            }
        }

        #endregion

        #region DeleteMilestone
        [HttpDelete("{milestoneID}")]

        public IActionResult DeleteMilestone(int milestoneID)
        {
            //if (!(User.IsInRole("Admin") || User.IsInRole("Project Manager")))
            //{
            //    return StatusCode(500, "You have not access to delete project's milestone");
            //}
            var isDeleted = _milestonesRepository.DeleteMilestone(milestoneID);
            if (isDeleted)
            {
                return Ok(new { Message = "Milestone deleted successfully" });
            }
            else
            {
                return NotFound(new { Message = "Milestone not found or Deletion failed" });
            }
            return NoContent();
        }
        #endregion
    }
}
