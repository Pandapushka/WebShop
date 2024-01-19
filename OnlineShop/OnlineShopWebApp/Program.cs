using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OnlineShop.Db.Models;
using OnlineShop.Db;
using Serilog;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineShopWebApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var userManager = services.GetRequiredService<UserManager<User>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                IdentityInitializer.Initialize(userManager, roleManager);
            }
            host.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
			.UseSerilog((HostingContext, configuration) =>
			{
				configuration
					.ReadFrom.Configuration(HostingContext.Configuration)
					.Enrich.WithProperty("ApplicationName", "Online Shop");
			})
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
