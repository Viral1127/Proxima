using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proxima.Data;

namespace Proxima.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminDashboardController : ControllerBase
    {
        private readonly AdminDashboardRepository _adminDashboard;

        public AdminDashboardController(AdminDashboardRepository repository)
        {
            _adminDashboard = repository;
        }

        [HttpGet("GetAdminDashboardData")]
        public IActionResult GetDashboardData()
        {
            try
            {
                var data = _adminDashboard.GetDashboardData();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while fetching dashboard data.", Error = ex.Message });
            }
        }
    }
}
