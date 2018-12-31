using System;
using System.Linq;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AspNetCoreWeb.UI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

      

        public IConfigurationRoot Configuration { get; private set; }
        public IContainer ApplicationContainer { get; private set; }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(this.Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            //app.UseMvc();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            //loggerFactory.AddConsole(minLevel:LogLevel.Information);
            //var logger = loggerFactory.CreateLogger("Middleware");
            //app.Use(async(context,next)=>{
            //    logger.LogInformation("Handing request");
            //    await next.Invoke();
            //    logger.LogInformation("Finished handing request");
            //});
            //app.Run(async context=> {
            //    await context.Response.WriteAsync("Hello from MiddleWare");
            //});
            app.UseStaticFiles();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }

       

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {


            services.Configure<DbConn>(Configuration.GetSection("ConnectionStrings"));
            services.AddMvc();
            ContainerBuilder builder = new ContainerBuilder();
            //将services中的服务填充到Autofac中.
            builder.Populate(services);
            //新模块组件注册
            builder.RegisterModule<DefaultModuleRegister>();
            ApplicationContainer = builder.Build();
            //使用容器创建 AutofacServiceProvider 
            return new AutofacServiceProvider(ApplicationContainer);
        }
    }
}
