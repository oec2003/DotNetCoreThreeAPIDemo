using System;
using Castle.DynamicProxy;

namespace AutofacNetCore3._1Demo.AOP
{
    public class UserServiceInterceptor:IInterceptor
    {
        public virtual void Intercept(IInvocation invocation)
        {
            Console.WriteLine($"{DateTime.Now}: 方法执行前");
            invocation.Proceed();
            Console.WriteLine($"{DateTime.Now}: 方法执行后");
        }
    }
}