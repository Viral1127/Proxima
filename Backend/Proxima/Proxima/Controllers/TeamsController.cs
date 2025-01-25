using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proxima.Data;
using Proxima.Models;

namespace Proxima.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly TeamsRepository _teamsRepository;

        public TeamsController(TeamsRepository teamsRepository) { 
            _teamsRepository = teamsRepository;
        }

        [HttpGet("Teams")]
        public IActionResult GetTeams()
        {
            var teams = _teamsRepository.GetTeams();
            return Ok(teams);
        }

        [HttpGet("Teams/{teamID}")]
        public IActionResult GetTeamByID(int teamID)
        { 
            var teams = _teamsRepository.GetTeamByID(teamID);
            if (teams == null) { 
                NotFound();
            }
            return Ok(teams);
        }
        [HttpGet("Team/{userID}")]
        
        public IActionResult GetTeamByUserID(int userID)
        {
            var teams = _teamsRepository.GetTeamByUserID(userID);
            if (teams == null)
            {
                NotFound();
            }
            return Ok(teams);
        }

        [HttpPost("Teams")]
        public IActionResult CreateTeam([FromBody] TeamsModel teams)
        {
            if (teams == null)
            {
                return BadRequest();
            }
            bool isInserted = _teamsRepository.CreateTeam(teams);

            if (isInserted)
            {
                return Ok(new { Message = "Team created succesfully" });
            }
            return StatusCode(500, "An error occured while creating Team");
        }

        [HttpPut("Teams/{teamID}")]
        public IActionResult UpdateTeam(int teamID, [FromBody] TeamsModel teams) { 
            if(teams == null || teamID != teams.TeamID)
            {
                return BadRequest();
            }
            var isUpdated = _teamsRepository.UpdateTeam(teams);
            if (isUpdated) {
                return Ok(new { Message = "Team Updated succesfully" });
            }
            else
            {
                return StatusCode(500, "An error occured while updating Team");
            }
        }

        [HttpDelete("Teams/{teamID}")]

        public IActionResult DeleteTeam(int teamID) { 
            var isDeleted = _teamsRepository.DeleteTeam(teamID);
            if (isDeleted) { 
                return Ok(new {Message = "Team deleted successfully"});
            }
            else
            {
                return NotFound(new { Message = "Team not found or Deletion failed" });
            }
            return NoContent();
        }

        [HttpPost("Teams/AddTeamMember")]
        public IActionResult AddTeamMember([FromBody] TeamMemberModel teamMember)
        {
            if (teamMember == null)
            {
                return BadRequest();
            }
            bool isInserted = _teamsRepository.AddTeamMember(teamMember);

            if (isInserted)
            {
                return Ok(new { Message = "Team member added succesfully" });
            }
            return StatusCode(500, "An error occured while adding Team member");
        }

        [HttpGet("TeamMembers/{teamID}")]
        public ActionResult<UserModel> GetUserByRole(int teamID)
        {
            var teamMembers = _teamsRepository.GetTeamMembersByTeamID(teamID);

            if (teamMembers == null)
            {
                return NotFound(new { message = $"User with team {teamID} not found." });
            }

            return Ok(teamMembers);
        }

        [HttpDelete("TeamMembers/{teamMemberID}")]

        public IActionResult RemoveTeamMember(int teamMemberID) { 
            var isDeleted = _teamsRepository.RemoveTeamMember(teamMemberID);
            if (isDeleted)
            {
                return Ok(new { Message = "TeamMember removed successfully" });
            }
            else
            {
                return NotFound(new {Message = "An error occured while removing teamMember or TeamMember not found"});
            }
            return NoContent();
        }
    }
}
