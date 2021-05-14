using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestTask.Data;
using TestTask.Data.Interfaces;
using TestTask.Data.Models;
using TestTask.Data.Repository;
using TestTask.Data.Validators;
using TestTask.Services;

namespace TestTask
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation();
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddRazorPages();
            services.AddMvc(options => options.EnableEndpointRouting = false).AddFluentValidation(); 
            services.AddTransient<ITenantsRepository, TenantsRepository>();
            services.AddTransient<IApartmentsRepository, ApartmentsRepository>();
            services.AddTransient<ITenantsService, TenantsService>();
            services.AddTransient<IApartmentsService, ApartmentsService>();
            services.AddTransient<IValidator<Tenant>, TenantValidator>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            else
            {
                app.UseExceptionHandler("/Error");

                app.UseHsts();
            }            

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
