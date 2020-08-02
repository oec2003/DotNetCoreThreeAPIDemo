using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExceptionDemo.Filters;
using ExceptionDemo.Repositories;
using ExceptionDemo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ExceptionDemo
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
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IDeptService,DeptService>();
            services.AddScoped<IDeptRepository,DeptRepository>();
            services.AddControllers(options =>
            {
                options.Filters.Add<CustomerExceptionAttribute>();
                options.Filters.Add<ResultFilterAttribute>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}