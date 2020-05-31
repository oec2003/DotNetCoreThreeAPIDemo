using System;

namespace InjectDemo
{
    public class Log:ILog
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}