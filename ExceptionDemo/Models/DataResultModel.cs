namespace ExceptionDemo.Models
{
    public class DataResultModel:ResultModelBase
    {
        public DataResultModel(object data,int? code = 200)
        {
            Code = code;
            Data = data;
        }

        public object Data { get; set; }
    }
}