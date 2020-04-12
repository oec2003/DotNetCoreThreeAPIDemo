using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ThreeAPIDemo.Middlewares
{
    public class RequestSourceCheckMiddleware:IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string urlRef = context.Request.Headers["Referer"];

            if (string.IsNullOrWhiteSpace(urlRef) || !urlRef.Contains("http://fwhyy.com"))
            {
                context.Response.StatusCode = 403; 
                await Task.CompletedTask;
            }
            else
            {
                await next.Invoke(context);
            }
        }
    }
}