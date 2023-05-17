using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            services.AddDbContext<Models.AppDbContext>();

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
                    pattern: "{controller=User}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "notification",
                    pattern: "{controller=Notification}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "joboffer",
                                       pattern: "{controller=JobOffer}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "jobofferuser",
                                       pattern: "{controller=JobOfferUser}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}