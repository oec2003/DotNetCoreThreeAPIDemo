using System;
using System.IO;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using ThreeAPIDemo.Services;

namespace ThreeAPIDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            services.AddScoped<IUserService,UserService>();
            
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo 
                {
                    Version = "v1",
                    Title = "DotNet Core WebAPI文档"
                });
            
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "ThreeAPIDemo.xml");
                options.IncludeXmlComments(xmlPath);
            });
            
            services.AddControllers()
                .AddXmlDataContractSerializerFormatters()
                .ConfigureApiBehaviorOptions(setup =>
                {
                    setup.InvalidModelStateResponseFactory = context =>
                    {
                        var details = new ValidationProblemDetails(context.ModelState)
                        {
                            Type = "http://api.oec2003.com/help",
                            Title = "实体验证错误",
                            Status = StatusCodes.Status422UnprocessableEntity,
                            Detail = "看详细",
                            Instance = context.HttpContext.Request.Path,
                        };
                        details.Extensions.Add("trachid",context.HttpContext.TraceIdentifier);
            
                        return new UnprocessableEntityObjectResult(details)
                        {
                            ContentTypes = { "application/problem+json" }
                        };
                    };
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseHttpsRedirection();
            
            app.UseRouting();
            
            app.UseAuthorization();
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DotNet Core WebAPI文档");
            });
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}