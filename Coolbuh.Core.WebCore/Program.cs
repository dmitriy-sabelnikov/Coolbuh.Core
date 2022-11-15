using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace Coolbuh.Core.WebCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<IDbContext>()?.UpdateDb();
            }
            
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging((_, builder) =>
                {

                    builder.AddFile(option =>
                    {
                        option.FileName = "CoolbuhLog_";
                        option.Extension = "txt";
                        option.LogDirectory = Environment.CurrentDirectory + "/Logs";
                    });
                })
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
