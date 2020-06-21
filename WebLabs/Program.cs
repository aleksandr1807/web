using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebLabs.Services;

namespace WebLabs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureLogging(log =>
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "fileInfoLog.txt");
                log.ClearProviders();
                log.AddProvider(new FileLoggerProvider(path));
                log.AddFilter("Microsoft", LogLevel.None);
            })
        //.UseStartup<Startup>();
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    }
}
