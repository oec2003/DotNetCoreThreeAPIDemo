using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionDemo.Models
{
    public class MessageResult:ObjectResult
    {
        public MessageResult(string message, int? code=200 )
            : base(new MessageResultModel(message,code))
        {
            StatusCode = 200;
        }
    }
}