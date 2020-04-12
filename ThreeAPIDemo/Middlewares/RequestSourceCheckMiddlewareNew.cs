using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ThreeAPIDemo.Middlewares
{
    public class RequestSourceCheckMiddlewareNew
    {
        private readonly RequestDelegate _next;

        public RequestSourceCheckMiddlewareNew(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            string urlRef = context.Request.Headers["Referer"];

            if (string.IsNullOrWhiteSpace(urlRef) || !urlRef.Contains("http://fwhyy.com"))
            { 
                context.Response.StatusCode = 403; 
                await Task.CompletedTask;
            }
            else
            {
                await  _next.Invoke(context);
            }
        }
    }
}