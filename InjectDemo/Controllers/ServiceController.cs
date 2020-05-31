using System;
using Microsoft.AspNetCore.Mvc;

namespace InjectDemo.Controllers
{  
    [ApiController]
    [Route("api/[controller]/{action}")]
    public class ServiceController
    {
      
        [HttpGet]
        public void GetService([FromServices]ISingletonService singleton1,
            [FromServices]ISingletonService singleton2,
            [FromServices]IScopedService scoped1,
            [FromServices]IScopedService scoped2,
            [FromServices]ITransientService transient1,
            [FromServices]ITransientService transient2
          )
        {
            System.Console.WriteLine($"singleton1:{singleton1.GetHashCode()}");
            System.Console.WriteLine($"singleton2:{singleton2.GetHashCode()}");
            System.Console.WriteLine($"scoped1:{scoped1.GetHashCode()}");
            System.Console.WriteLine($"scoped2:{scoped2.GetHashCode()}");
            System.Console.WriteLine($"transient1:{transient1.GetHashCode()}");
            System.Console.WriteLine($"transient2:{transient2.GetHashCode()}");
        }
    }
}