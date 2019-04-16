using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Threading.Tasks;

namespace MiddleWareSample.Helpers
{
    public class TestHeaderValidator
    {
        private RequestDelegate _next;

        public TestHeaderValidator(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Headers["test"].Equals("lovaraju"))
            {
                await _next.Invoke(context);
            }
            else
            {
                context.Response.StatusCode = 400;
                context.Response.Body.Write(Encoding.ASCII.GetBytes("Invalid test header"));
            }
        }
    }

    public static class TestHeaderValidatorExtension
        {
            public static IApplicationBuilder UseTestHeaderValidator(this IApplicationBuilder app)
            {
                app.UseMiddleware<TestHeaderValidator>();
                return app;
            }
        }
}
