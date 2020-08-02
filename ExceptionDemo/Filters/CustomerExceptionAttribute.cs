using System.Net;
using ExceptionDemo.Common.CustomerException;
using ExceptionDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ExceptionDemo.Filters
{
    public class CustomerExceptionAttribute: IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;

            int code = (int) status;
            //处理各种异常
            if (context.Exception is UserNotFoundException)
            {
                code = 500001;
            }else if(context.Exception is DeptNotFoundException)
            {
                code = 500002;
            }else if (context.Exception is UserFullNameGenException)
            {
                code = 500100;
            }
            context.Result = new CustomExceptionResult(context.Exception,status ,code);
            context.ExceptionHandled = true;
        }
    }
}