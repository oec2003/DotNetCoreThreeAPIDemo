using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
namespace ExceptionDemo.Models
{
    public class DataResult: ObjectResult
    {
        public DataResult(object data , int? code=200 )
            : base(new DataResultModel(data,code))
        {
            StatusCode = 200;
        }
    }
}