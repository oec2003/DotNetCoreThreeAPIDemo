using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace MiddlewareDemo1
{
    class Program
    {
        static void Main(string[] args)
        {
            Host.CreateDefaultBuilder()
                .ConfigureWebHost(builder => builder
                    .Configure(app => app
                        .Run(context => context.Response.WriteAsync("hello world!")))
                    .UseKestrel()
                    .UseUrls("http://localhost:5000"))
                .Build()
                .Run();
        }
    }
}