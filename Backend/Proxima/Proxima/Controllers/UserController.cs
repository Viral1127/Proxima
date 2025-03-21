﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proxima.Data;
using Proxima.Models;

namespace Proxima.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        public UserController(UserRepository userRepository) {
            _userRepository = userRepository;
        }

        #region GetAllUsers
        [HttpGet("GetAllUsers")]
        public ActionResult<IEnumerable<UserModel>> GetAllUsers()
        {
            //if (!User.IsInRole("Admin"))
            //{
            //    return StatusCode(500, "Only Admin can view List of users");
            //}
            var users = _userRepository.GetUsers();
            return Ok(users);

        }
        #endregion

        [HttpGet("GetUserRoleCounts")]
        public async Task<ActionResult<List<UserRoleCount>>> GetUserRoleCounts()
        {
            var result = await _userRepository.GetUserRoleCountsAsync();
            return Ok(result);
        }

        #region GetUserByUserID
        [HttpGet("GetUserByID/{userID}")]
        public ActionResult<UserModel> GetUserById(int userID)
        {
            var user = _userRepository.GetUserByID(userID);

            if (user == null)
            {
                return NotFound(new { message = $"User with ID {userID} not found." });
            }

            return Ok(user);
        }
        #endregion

        #region UserByRole
        [HttpGet("UserByRole/{roleID}")]
        public ActionResult<UserModel> GetUserByRole(int roleID)
        {
            if (!User.IsInRole("Admin"))
            {
                return StatusCode(500, "Only Admin can view users by it's roles");
            }
            var user = _userRepository.GetUserByRole(roleID);

            if (user == null)
            {
                return NotFound(new { message = $"User with role {roleID} not found." });
            }

            return Ok(user);
        }
        #endregion

        #region UpdateUser
        [HttpPut("/UpdateUser{userID}")]
        public IActionResult UpdateUser(int userID, UserModel user)
        {
            if (user == null || userID != user.UserID)
            {
                return BadRequest(new { Message = "Invalid input. User ID mismatch or null user data." });
            }

            bool isUpdated = _userRepository.UpdateUser(user);

            if (isUpdated)
            {
                return Ok(new { Message = "User updated successfully." });
            }
            else
            {
                return NotFound(new { Message = "User not found or update failed." });
            }
        }
        #endregion

        #region DeactivateUser
        [HttpDelete("DeactivateUser/{userID}")]
        public IActionResult DeactivateUser(int userID) {
            if (!User.IsInRole("Admin"))
            {
                return StatusCode(500, "Only Admin can deactivate User");
            }
            var isDeactivated = _userRepository.DeactivateUser(userID);
            if (isDeactivated) {
                return Ok(new { Message = "User deactivated successfully." });
            }
            else
            {
                return NotFound(new { Message = "User not found or deactivation failed." });
            }
        }
        #endregion

        #region DeleteUser
        [HttpDelete("DeleteUser/{userID}")]
        public IActionResult DeleteUser(int userID)
        {
            if (!User.IsInRole("Admin"))
            {
                return StatusCode(500, "Only Admin can delete user");
            }
            var isDeleted = _userRepository.DeleteUser(userID);
            if (isDeleted)
            {
                return Ok(new { Message = "User deleted successfully." });
            }
            else
            {
                return NotFound(new { Message = "User not found or delete failed." });
            }
        }
        #endregion

    }
}
