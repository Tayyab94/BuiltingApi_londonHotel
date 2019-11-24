using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace London_Api_corePractice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            InitializeDatabase(host);
               host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        public static void InitializeDatabase(IWebHost host)
        {
            using(var scope=host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    SeedData.initializeAsync(services).Wait();
                }
                catch (Exception e)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();

                    logger.LogError(e, "An Error  occur While Seeding the DataBasse....");
                }
            }
        }
    }
}
