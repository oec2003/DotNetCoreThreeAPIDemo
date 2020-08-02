namespace ExceptionDemo.Models
{
    public class MessageResultModel:ResultModelBase
    {
        public MessageResultModel(string massage,int? code = 200)
        {
            Code = code;
            Message = massage;
        }

        public string Message { get; set; }
    }
}