using Microdev.ASPNETCore.Models;
using Microdev.ASPNETCore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Microdev.ASPNETCore
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<EmployeeService>();
            services.AddTransient<TestEmployeeService>();
            services.AddTransient<Func<EnviromentServiceType, IEmployeeService>>(serviceProvider => key =>
            {
                switch (key)
                {
                    case EnviromentServiceType.ProductionEmployeeService:
                        return serviceProvider.GetRequiredService<EmployeeService>();
                    case EnviromentServiceType.TestEmployeeService:
                        return serviceProvider.GetRequiredService<TestEmployeeService>();
                    default:
                        throw new NotImplementedException($"Service of type {key} is not   implemented.");
                }
            });

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseStatusCodePages();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/Home/error/{0}");
            }



            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "employee",
                    pattern: "{controller=Employee}/{action=GetAllEmployee}/{id?}");


            });



        }
    }

}
