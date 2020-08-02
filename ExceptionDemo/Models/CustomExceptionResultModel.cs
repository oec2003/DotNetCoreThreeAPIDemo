using System;

namespace ExceptionDemo.Models
{
    public class CustomExceptionResultModel:ResultModelBase
    {
        public CustomExceptionResultModel(Exception exception,int? code = 500)
        {
            Code = code;
            ProcessException(exception);
        }

        public string Reason { get; set; }
        public string StackTrace { get; set; }
        
        private void ProcessException(Exception exception)
        {
            this.Reason = $"Message:{exception.Message},InnerMessage:{exception.InnerException?.Message}";
            this.StackTrace = exception.StackTrace;
        }
    }
}