using Microsoft.AspNetCore.Builder;
using ThreeAPIDemo.Middlewares;

namespace ThreeAPIDemo.Extensions
{
    public static class RequestSourceCheckMiddlewareExtension
    {
        public static IApplicationBuilder UseRequestSourceCheck(this IApplicationBuilder app)
        {
            app.UseMiddleware<RequestSourceCheckMiddleware>();
            return app;
        }
        
        public static IApplicationBuilder UseRequestSourceCheckNew(this IApplicationBuilder app)
        {
            app.UseMiddleware<RequestSourceCheckMiddlewareNew>();
            return app;
        }
    }
}