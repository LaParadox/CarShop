using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarShop.Data.interfaces;
using CarShop.Data.mocks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using CarShop.Data;
using Microsoft.EntityFrameworkCore;
using CarShop.Data.Repository;
using CarShop.Data.Models;

namespace CarShop
{
    public class Startup
    {
        private IConfigurationRoot _confSting;

        [Obsolete]
        public Startup(IHostingEnvironment hostEnv)
        {
            _confSting = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confSting.GetConnectionString("DefaultConnection")));
            services.AddTransient<IAllCars, CarRepository>();
            services.AddTransient<ICarsCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession(); 
        }
       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseCookiePolicy();
            app.UseStatusCodePages();
            app.UseSession();
            /*   app.UseAuthentication();
               app.UseAuthorization();*/
            using (var scope = app.ApplicationServices.CreateScope())
            {
               AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("{admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("categoryFilter", "Car/{action}/{category?}", defaults: new { Controller="Car",action="List"});
            });
            /* app.UseRouting();
             app.UseDeveloperExceptionPage();
             app.UseStatusCodePages();
             app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();*/

        }
    }
}
