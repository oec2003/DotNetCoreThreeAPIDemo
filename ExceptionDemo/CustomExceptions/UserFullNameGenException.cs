using System;

namespace ExceptionDemo.Common.CustomerException
{
    public class UserFullNameGenException: Exception
    {
        public UserFullNameGenException() { }
        public UserFullNameGenException(string message) : base(message) { }
        public UserFullNameGenException(string message, Exception inner) : base(message, inner) { }
    }
}