using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repository;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Repository;
using Serilog;
using System;

namespace OnlineShopWebApp
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
			string connection = Configuration.GetConnectionString("online_shop");
			services.AddDbContext<DatabaseContext>(options =>
				options.UseSqlServer(connection));
            
			services.AddDbContext<IdentityContext>(options => options.UseSqlServer(connection));

			services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<IdentityContext>();

			services.ConfigureApplicationCookie(options =>
			{
				options.ExpireTimeSpan = TimeSpan.FromHours(24);
				options.LoginPath = "/Login/Index";
                options.LogoutPath = "/Login/Logout";
				options.Cookie = new CookieBuilder
				{
					IsEssential = true
				};

			});


            services.AddControllersWithViews();
			services.AddTransient<IProductsRepository, InDbProductsRepository>();
			services.AddTransient<ICartsRepository, InDbCartsRepository>();
			services.AddTransient<IOrdersRepository, InDbOrderRepository>();
			services.AddSingleton<IRolesRepository, InMemoryRolesRepository>();
            services.AddSingleton<ImagesProvider>();

        }

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
            app.UseSerilogRequestLogging();
            app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
