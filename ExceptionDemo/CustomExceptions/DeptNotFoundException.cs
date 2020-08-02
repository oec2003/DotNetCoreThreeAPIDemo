using System;

namespace ExceptionDemo.Common.CustomerException
{
    public class DeptNotFoundException : Exception
    {
        public DeptNotFoundException() { }
        public DeptNotFoundException(string message) : base(message) { }
        public DeptNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}