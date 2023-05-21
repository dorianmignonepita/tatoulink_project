
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using tatoulink.Account;

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
            // services.AddAutoMapper(typeof(DataAccess.AutomapperProfiles));

            services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AuthDbContext>();

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

            app.UseAuthentication();

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