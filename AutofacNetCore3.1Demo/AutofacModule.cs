using Autofac;
using InjectLib;
using Microsoft.Extensions.DependencyInjection;

namespace AutofacNetCore3._1Demo
{
    public class AutofacModule:Autofac.Module
    {
        private static IContainer _container;

        protected override void Load(ContainerBuilder builder)
        {
            // builder.RegisterAssemblyTypes(typeof(Program).Assembly)
            //     .Where(t => t.Name.EndsWith("Service"))
            //     .AsImplementedInterfaces()
            //     .InstancePerLifetimeScope();


            // builder.RegisterType<DeptService>().As<IDeptService>()
            //     .InstancePerLifetimeScope();
            // builder.RegisterType<UserService>().As<IUserService>()
            //     .PropertiesAutowired()
            //     .InstancePerLifetimeScope();

            // builder.RegisterType<UserServiceInterceptor>();
            // builder.RegisterType<UserService>().As<IUserService>()
            //   .EnableInterfaceInterceptors()
            //    .InstancePerLifetimeScope();

            // var controllerBaseType = typeof(ControllerBase); 
            // builder.RegisterAssemblyTypes(typeof(Program).Assembly)
            //     .Where(t => controllerBaseType.IsAssignableFrom(t) && t != controllerBaseType)
            //     .PropertiesAutowired();

            // builder.RegisterType<Engine>().As<IEngine>().SingleInstance();
            
            //add autofac
            // var builder = new ContainerBuilder();
            //builder.Populate(services);
            //builder.RegisterAssemblyTypes(typeof(Startup).Assembly).AsImplementedInterfaces();
            builder.RegisterType<Engine>().As<IEngine>().As<IStartable>().SingleInstance();
            
            //builder.RegisterBuildCallback(container => _container = container);
            //builder.RegisterBuildCallback(container =>container.Resolve<IEngine>().Start());
            // IEngine engine = _container.Resolve<IEngine>();
            // engine.Start();
            // engine.OnLoad();
        }

        public static IContainer GetContainer()
        {
            return _container;
        }
    }
}