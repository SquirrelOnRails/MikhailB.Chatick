using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MikhailB.Chatick.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog((context, configuration) => 
                {
                    configuration
                        .MinimumLevel.Is(LogEventLevel.Information)
                        .Enrich.FromLogContext()
                        .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Debug)
                        .WriteTo.File(
                            formatter: new Serilog.Formatting.Json.JsonFormatter(null, false, null),
                            path: $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}{System.IO.Path.DirectorySeparatorChar}Logs{System.IO.Path.DirectorySeparatorChar}log.txt",
                            restrictedToMinimumLevel: LogEventLevel.Verbose,
                            fileSizeLimitBytes: 10 * 1024 * 1024, // 10Mb
                            levelSwitch: new Serilog.Core.LoggingLevelSwitch(LogEventLevel.Information),
                            rollingInterval: RollingInterval.Day,
                            rollOnFileSizeLimit: true,
                            retainedFileTimeLimit: TimeSpan.FromDays(31),
                            encoding: System.Text.Encoding.UTF8);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
