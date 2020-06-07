using System;
using Autofac.Extras.DynamicProxy;
using AutofacNetCore3._1Demo.AOP;

namespace AutofacNetCore3._1Demo.Services
{
    [Intercept(typeof(UserServiceInterceptor))]
    public class UserService: IUserService
    {
        //public IDeptService DeptService { get; set; }
        public string GetUserName()
        {
            Console.WriteLine($"{DateTime.Now}: 方法执行中");
            return "oec2003";
            //return $"oec2003({DeptService.GetDeptName()})";
        }
    }
}