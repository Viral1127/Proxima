using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proxima.Data;
using Proxima.Models;

namespace Proxima.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RolesRepository _rolesRepository;

        public RolesController(RolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        #region GetAllRoles
        [HttpGet("GetAllRoles")]
        public IActionResult GetRoles()
        {
            var roles = _rolesRepository.GetRoles();
            return Ok(roles);
        }
        #endregion

        #region GetRoleByID
        [HttpGet("GetRoleByID/{roleID}")]
        public IActionResult GetRoleByID(int roleID)
        {
            var role = _rolesRepository.GetRoleByID(roleID);
            if (role == null)
            { 
                return NotFound();
            }
            return Ok(role);
        }
        #endregion

        #region AddRole
        [HttpPost("CreateRole")]
        public IActionResult CreateRoles([FromBody] RolesModel roles)
        {
            if (roles == null)
            {
                return BadRequest();
            }
            bool isInserted = _rolesRepository.CreateRole(roles);

            if (isInserted)
            {
                return Ok(new { Message = "Role created succesfully" });
            }
            return StatusCode(500, "An error occured while creating role or role already exist");
        }
        #endregion

        #region RemoveRole
        [HttpDelete("RemoveRole{roleID}")]
        public IActionResult DeleteRoles(int roleID) 
        {
            var isDeleted = _rolesRepository.DeleteRole(roleID);
            if (isDeleted) { 
                return Ok(new {Message = "Role Deleted successfully"});
            }
            else
            {
                return NotFound(new { Message = "Role not found or Deletion failed" });
            }
            return NoContent();
        }
        #endregion
    }
}
