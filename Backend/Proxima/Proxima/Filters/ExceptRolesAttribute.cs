using Microsoft.AspNetCore.Mvc;

namespace Proxima.Filters
{
    public class ExceptRolesAttribute : TypeFilterAttribute
    {
        public ExceptRolesAttribute(string roles) : base(typeof(ExceptRolesFilter))
        {
            Arguments = new object[] { roles };
        }
    }
}
