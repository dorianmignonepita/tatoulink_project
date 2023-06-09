﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using tatoulink.DataAccess.EfModels;
using Microsoft.EntityFrameworkCore;

namespace tatoulink
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
            // Configuration des services nécessaires à votre application
            services.AddControllersWithViews();
            services.AddDbContext<DataAccess.EfModels.DbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(typeof(DataAccess.AutomapperProfiles));

            services.AddTransient<DataAccess.Interfaces.IJobOfferRepository, DataAccess.Repositories.JobOfferRepository>();
            services.AddTransient<DataAccess.Interfaces.IJobOfferUserRepository, DataAccess.Repositories.JobOfferUserRepository>();
            services.AddTransient<DataAccess.Interfaces.INotificationRepository, DataAccess.Repositories.NotificationRepository>();
            services.AddTransient<DataAccess.Interfaces.IUserRepository, DataAccess.Repositories.UserRepository>();


            // Configuration de la prise en charge des vues
            services.AddRazorPages();
            services.AddMvc().AddRazorRuntimeCompilation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "user",
                    pattern: "{controller=UserDTO}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "notification",
                    pattern: "{controller=NotificationDTO}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "joboffer",
                                       pattern: "{controller=JobOfferDTO}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "jobofferuser",
                                       pattern: "{controller=JobOfferUserDTO}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}