using System.Security.Claims;

namespace Proxima
{
    public class CommonVariable
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CommonVariable(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserEmail()
        {
            return _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Email)?.Value;
        }

        public string GetUserRole() 
        { 
            return _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Role)?.Value;
        }
        public string GetUserName() 
        {
            return _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
        }
    }
}
