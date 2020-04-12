using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MiddlewareDemo
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(next =>
            {
                Console.WriteLine("第一个中间件");
                return new RequestDelegate(async context =>
                {
                    await context.Response.WriteAsync("First Middleware Begin >>>");
                    await next.Invoke(context);
                    await context.Response.WriteAsync($"First Middleware >>>");
                });
            });
            app.Use(next =>
            {
                Console.WriteLine("第二个中间件");
                return new RequestDelegate(async context =>
                {
                    await context.Response.WriteAsync("Second Middleware Begin >>>");
                    await context.Response.WriteAsync("Second Middleware End >>>");
                    
                });
            });
        }
    }
}