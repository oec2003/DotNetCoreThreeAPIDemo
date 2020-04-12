using Microsoft.AspNetCore.Mvc.Filters;

namespace ThreeAPIDemo.Filters
{
    public class CustomExceptionAttribute:ExceptionFilterAttribute
    {
        public CustomExceptionAttribute()
        {
            
        }
        public override void OnException(ExceptionContext context)
        {
            var ex = context.Exception.Message;
        }
    }
}