using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionDemo.Models
{
    public class CustomExceptionResult:ObjectResult
    {
        public CustomExceptionResult(Exception exception,HttpStatusCode statusCode,  int? code=500 )
            : base(new CustomExceptionResultModel(exception,code))
        {
            StatusCode = (int)statusCode;
        }
    }
}