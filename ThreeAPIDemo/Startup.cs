using System;
using System.IO;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using ThreeAPIDemo.Extensions;
using ThreeAPIDemo.Middlewares;
using ThreeAPIDemo.Models;
using ThreeAPIDemo.Services;

namespace ThreeAPIDemo
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            services.AddScoped<IUserService,UserService>();
            services.AddSingleton(new RequestSourceCheckMiddleware());
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

            // jwt 认证
            JwtSettings jwtSettings = new JwtSettings();
            services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));
            Configuration.GetSection("JwtSettings").Bind(jwtSettings);
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o=>
                {
                    o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        //用于签名验证
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.SecretKey)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddCors(options =>
            {
                options.AddPolicy("any", builder =>
                {
                    builder.WithOrigins("http://localhost:8080").AllowAnyHeader();
                });
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
            
            app.UseCors("any");
            // app.UseRequestSourceCheckNew();
            // app.UseRequestSourceCheck();
            app.UseAuthentication();
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