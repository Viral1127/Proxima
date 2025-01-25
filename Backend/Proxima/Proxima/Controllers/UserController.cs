using Microsoft.AspNetCore.Http;
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
        [HttpGet("GetAllUsers")]
        public ActionResult<IEnumerable<UserModel>> GetAllUsers()
        {

            var users = _userRepository.GetUsers();
            return Ok(users);

        }

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

        [HttpGet("UserByRole/{roleID}")]
        public ActionResult<UserModel> GetUserByRole(int roleID)
        {
            var user = _userRepository.GetUserByRole(roleID);

            if (user == null)
            {
                return NotFound(new { message = $"User with role {roleID} not found." });
            }

            return Ok(user);
        }

        [HttpPost("Register")]
        public IActionResult RegisterUser(UserModel user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest();
                }

                bool isInserted = _userRepository.Register(user);
                if (isInserted)
                {
                    return Ok(new { Message = "User registered successfully" });
                }
                return StatusCode(500, "An unexpected error occurred.");
            }
            catch (Exception ex) {
                return StatusCode(500, new { Message = $"An error occurred: {ex.Message}" });
            }
            
            
        }

        [HttpPost("AuthenticateUser")]
        public IActionResult AuthenticateUser([FromBody] LoginModel login)
        {
            if (login == null || string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Password))
            {
                return BadRequest(new { Message = "Invalid Data Provided" });
            }

            try
            {
                var user = _userRepository.AuthenticateUser(login.Email, login.Password);

                if (user == null)
                {
                    return Unauthorized(new { Message = "Invalide Email or Password" });
                }

                if (user.Status == false)
                {
                    return Unauthorized(new { Message = "Your account is inactive. Please contact admin." });
                }

                return Ok(new { Message = "Login Successfull", userID = user.UserID, Name = user.Name, Email = user.Email, RoleName = user.RoleName, Status = user.Status });
            }
            catch (Exception ex) {
                return StatusCode(500, new { Message = $"An error occured:{ex.Message}" });
            }
        }

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

        [HttpDelete("DeactivateUser/{userID}")]
        public IActionResult DeactivateUser(int userID) { 
            var isDeactivated = _userRepository.DeactivateUser(userID);
            if (isDeactivated) {
                return Ok(new { Message = "User deactivated successfully." });
            }
            else
            {
                return NotFound(new { Message = "User not found or deactivation failed." });
            }
        }

        [HttpDelete("DeleteUser/{userID}")]
        public IActionResult DeleteUser(int userID)
        {
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


    }
}
