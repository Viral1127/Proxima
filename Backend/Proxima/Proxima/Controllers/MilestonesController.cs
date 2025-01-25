﻿using Microsoft.AspNetCore.Http;
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
            var milestone = _milestonesRepository.GetTeamByID(milestoneID);
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
        public IActionResult CreateMilestones([FromBody] MilestonesModel milestones)
        {
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

        #region AchivedMilestone
        [HttpDelete("{milestoneID}")]

        public IActionResult DeleteMilestone(int milestoneID)
        {
            var isDeleted = _milestonesRepository.DeleteMilestone(milestoneID);
            if (isDeleted)
            {
                return Ok(new { Message = "Milestone achived successfully" });
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
