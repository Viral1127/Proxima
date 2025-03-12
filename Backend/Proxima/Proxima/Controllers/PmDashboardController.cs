using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proxima.Data;

namespace Proxima.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PmDashboardController : ControllerBase
    {
        private readonly PmDashboardRepository _pmDashboard;

        public PmDashboardController(PmDashboardRepository repository)
        {
            _pmDashboard = repository;
        }

        [HttpGet("GetProjectManagerDashboardData/{userID}")]
        public IActionResult GetPmDashboardData(int userID)
        {
            try
            {
                var data = _pmDashboard.GetDashboardData(userID);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while fetching dashboard data.", Error = ex.Message });
            }
        }
    }
}
