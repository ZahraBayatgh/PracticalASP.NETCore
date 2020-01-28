using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microdev.ASPNETCore.Models;
using Microdev.ASPNETCore.Services;
using Microsoft.Extensions.Hosting;


namespace Microdev.ASPNETCore
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<EmployeeService>();
            services.AddTransient<TestEmployeeService>();
            services.AddTransient<SeedData>();
            services.AddTransient<Func<EnviromentServiceType, IEmployeeService>>(serviceProvider => key =>
            {
                switch (key)
                {
                    case EnviromentServiceType.ProductionEmployeeService:
                        return serviceProvider.GetRequiredService<EmployeeService>();
                    case EnviromentServiceType.TestEmployeeService:
                        return serviceProvider.GetRequiredService<TestEmployeeService>();
                    default:
                        throw new NotImplementedException($"Service of type {key} is not implemented.");
                }
            });
            var connection = _configuration.GetConnectionString("MicrodevConnection");
            services.AddDbContext<MicrodevDbContext>(
                options => options.UseSqlServer(connection)
            );
            services.AddIdentity<User, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<MicrodevDbContext>();

            services.AddAuthentication();
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

            app.UseAuthentication();
            app.UseAuthorization();
            // Seed the database
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<SeedData>();
                seeder.Seed().Wait();
            }

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
