using DepartmentDBContext;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Parcel.Handling.Infra.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcel.Handling.WebApi
{
    public class Program
    {
            public static async Task Main(string[] args)
            {
                var webHost = CreateHostBuilder(args).Build();
                await InitializeDatabase(webHost);
                await webHost.RunAsync();

            }
        private static Task InitializeDatabase(IHost webHost)
        {
            using var scope = webHost.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var seedData = new SeedData(context);
            seedData.Seed();
            return Task.CompletedTask;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
