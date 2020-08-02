using ExceptionDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ExceptionDemo.Filters
{
    public class ResultFilterAttribute:ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var objectResult = context.Result as ObjectResult;
            if (objectResult?.Value == null)
            {
                context.Result=new NotFoundObjectResult(new MessageResult("未找到资源"));
            }
            
            if (context.Result is MessageResult)
            {
                context.Result = new MessageResult(objectResult.Value.ToString());
            }
            else if (context.Result is OkObjectResult || context.Result is ObjectResult)
            {
                context.Result = new DataResult(objectResult.Value);
            }
        }
    }
}