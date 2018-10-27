using CarrierPidgeon.BatchDriven;
using CarrierPidgeon.InterfaceLoad;
using CarrierPidgeon.Core.Notifications;
using CarrierPidgeon.EventDriven;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using System.IO;
using System.Threading.Tasks;

namespace CarrierPidgeon
{
    public static class Program
    {
        public async static Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true)
                .Build();

            var conn = config.GetSection("Configuration:NotificationConnection").Value;

            var hostBuilder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
            {
                services.AddTransient<IAssemblyInfo, AssemblyInfo>()
                    .AddSingleton<INotificationSender>(ns =>
                    {
                        return new DefaultNotifiationSender(new MongoClient(conn));
                    })
                    .AddTransient<IFileSystem, FileSystem>()
                    .AddSingleton<IBatchDrivenInterfaceManager, BatchDrivenInterfaceManager>()
                    .AddSingleton<IEventDrivenInterfaceManager, EventDrivenInterfaceManager>()
                    .AddSingleton<IHostedService, Startup>();
            });

            await hostBuilder.RunConsoleAsync();
        }
    }
}
