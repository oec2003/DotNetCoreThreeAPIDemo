using System;
using Autofac;

namespace InjectLib
{
    public class Engine:IEngine,IStartable
    {
        public Engine()
        {
            UserManager=new UserManager();
            
            Console.WriteLine("ctor....");
        }
        
        public IUserManager UserManager { get; }

        public void Start()
        {
            Console.WriteLine("start....");
            
            OnLoad();
        }

        public void OnLoad()
        {
            Console.WriteLine("onload....");
        }
    }
}