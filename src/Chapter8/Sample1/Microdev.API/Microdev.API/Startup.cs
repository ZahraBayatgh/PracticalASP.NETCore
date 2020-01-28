using MediatR;
using Microdev.API.Application.Commands;
using Microdev.API.Application.Queries;
using Microdev.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Microdev.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var applicationConnectionString = Configuration.GetConnectionString("MicrodevAppDbContext");
            
            services.AddDbContext<MicrodevAppDbContext>(options =>
            options.UseSqlServer(applicationConnectionString));
            services.AddMediatR(typeof(CreateDepartmentCommandHandler));
            services.AddScoped<IDepartmentQueries, DepartmentQueries>(serviceProvider =>
            {
                return new DepartmentQueries(applicationConnectionString);
            });

            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
