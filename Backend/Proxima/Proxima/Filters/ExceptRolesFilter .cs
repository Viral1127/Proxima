using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Proxima.Filters
{
    public class ExceptRolesFilter : IAuthorizationFilter
    {
        private readonly List<string> _roles;

        public ExceptRolesFilter(string roles)
        {
            _roles = roles.Split(',').ToList();
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            if (!user.Identity.IsAuthenticated)
            {
                // Redirect to Login if not authenticated
                context.Result = new UnauthorizedResult();
                return;
            }

            foreach (var role in _roles)
            {
                if (user.IsInRole(role))
                {
                    // Restrict access if the user belongs to the restricted role
                    context.Result = new ForbidResult();
                    return;
                }
            }
        }
    }
}
