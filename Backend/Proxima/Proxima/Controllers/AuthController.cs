using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proxima.Data;
using Proxima.Models;

namespace Proxima.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthRepository _authRepository;
        public AuthController(AuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        #region Register User
        [HttpPost("Register")]
        public IActionResult RegisterUser(UserModel user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest();
                }

                bool isInserted = _authRepository.Register(user);
                if (isInserted)
                {
                    return Ok(new { Message = "User registered successfully" });
                }
                return StatusCode(500, "An unexpected error occurred.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An error occurred: {ex.Message}" });
            }


        }
        #endregion

        #region Authenticate User
        [HttpPost("AuthenticateUser")]
        public async Task<IActionResult> AuthenticateUser([FromBody] LoginModel login)
        {
            if (login == null || string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Password))
            {
                return BadRequest(new { Message = "Invalid Data Provided" });
            }

            try
            {
                var user = _authRepository.AuthenticateUser(login.Email, login.Password);

                if (user == null)
                {
                    return Unauthorized(new { Message = "Invalide Email or Password" });
                }

                if (user.Status == false)
                {
                    return Unauthorized(new { Message = "Your account is inactive. Please contact admin." });
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.RoleName)
                };

                var identity = new ClaimsIdentity(claims , CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return Ok(new 
                { 
                    Message = "Login Successfull",
                    userID = user.UserID,
                    Name = user.Name,
                    Email = user.Email,
                    RoleName = user.RoleName,
                    Status = user.Status 
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An error occured:{ex.Message}" });
            }
        }
        #endregion

        #region Get Loggedin UserInfo
        [HttpGet("GetUserInfo")]
        public IActionResult GetUserInfo()
        {
            try
            { 
                var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
                var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

                if (userEmail == null || userRole == null)
                {
                    return Unauthorized(new { Message = "User is not authenticated" });
                }

                return Ok(new
                {
                    Email = userEmail,
                    Role = userRole
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An error occurred: {ex.Message}" });
            }
        }
        #endregion

    }
}
