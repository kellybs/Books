using Autofac;
using System;
using System.Linq;

namespace AspNetCoreWeb.UI
{
    public class DefaultModuleRegister: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //注册当前程序集中以“Ser”结尾的类,暴漏类实现的所有接口，生命周期为PerLifetimeScope
            //builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("Ser")).AsImplementedInterfaces().InstancePerLifetimeScope();
            //builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            //注册所有"MyApp.Repository"程序集中的类
            builder.RegisterAssemblyTypes(GetAssembly("AspNet.Repository")).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(GetAssembly("AspNetCore.Services")).Where(t => t.Name.EndsWith("Services")).AsImplementedInterfaces().InstancePerLifetimeScope();
        }

        public static System.Reflection.Assembly GetAssembly(string assemblyName)
        {
            var assembly = System.Runtime.Loader.AssemblyLoadContext.Default.LoadFromAssemblyPath(AppContext.BaseDirectory + $"{assemblyName}.dll");
            return assembly;
        }

    }
}
