using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text;
using MiddleWareSample.Helpers;
using MiddleWareSample.Filters;

namespace MiddleWareSample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(config =>
            {
                config.Filters.Add(typeof(AuthorizationFilter));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseTestHeaderValidator();
            app.UseMvc();

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.Body.WriteAsync(Encoding.Default.GetBytes("first component\n"));
            //    await next.Invoke();
            //});

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.Body.WriteAsync(Encoding.Default.GetBytes("second component"));
            //    await next.Invoke();
            //});

            //app.Map(new Microsoft.AspNetCore.Http.PathString("/lovaraju"), branch =>
            //{
            //    branch.Run(async (context) =>
            //    {
            //        await context.Response.Body.WriteAsync(Encoding.ASCII.GetBytes("path of lovaraju"));
            //    });
            //});

            //app.MapWhen(context => context.Request.Query.ContainsKey("test"), appBuilder =>
            //{
            //    appBuilder.Run(async (context) =>
            //    {
            //        await context.Response.Body.WriteAsync(Encoding.ASCII.GetBytes("Map When testing"));
            //    });
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.Body.WriteAsync(Encoding.Default.GetBytes("Run test"));
            //});
        }
    }
}
