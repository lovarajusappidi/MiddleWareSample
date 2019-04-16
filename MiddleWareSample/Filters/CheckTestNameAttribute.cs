using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MiddleWareSample.Filters
{
    public class CheckTestNameAttribute : TypeFilterAttribute
    {
        public CheckTestNameAttribute() : base(typeof(CheckTestName))
        {
        }
    }

    public class CheckTestName : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Headers["test"].Equals("lovaraju"))
            {
                context.Result = new BadRequestObjectResult("Invalid Header");
            }
        }
    }
}
