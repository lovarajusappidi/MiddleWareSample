using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MiddleWareSample.Filters
{
    public class AuthorizationFilterAttribute : TypeFilterAttribute
    {
        public AuthorizationFilterAttribute() : base(typeof(AuthorizationFilter))
        {
        }
    }

    public class AuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers["token"].Equals("raju"))
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
