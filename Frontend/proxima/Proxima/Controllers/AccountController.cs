using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proxima.Models;
using Microsoft.AspNetCore.Authorization;

namespace Proxima.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient
            {
                BaseAddress = new System.Uri(_configuration["WebApiBaseUrl"])
            };
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterModel user)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync("api/Auth/Register", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "User registered successfully! Please log in.";
                    return RedirectToAction("Login", "Account"); // Redirect to Login Page
                }
                else
                {
                    ViewBag.Message = "Registration failed. Please try again.";
                    return View("Register",user);
                }
            }
            return View("Register",user);
        }

        public IActionResult Login()
        {
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLoginModel login)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(login);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync("api/Auth/AuthenticateUser", content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var user = JsonConvert.DeserializeObject<UserRegisterModel>(result);

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.RoleName),
                        new Claim("UserID", user.UserID.ToString())
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    Console.WriteLine(claims);
                    if(user.RoleName == "Admin")
                    {
                        return RedirectToAction("Index", "AdminDashboard");
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "Invalid email or password.";
                    return View("Login",login);
                }
            }
            return View("Login",login);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }



    }
}
