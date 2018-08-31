using CarrierPidgeon.BatchDriven;
using CarrierPidgeon.Core.Notifications;
using CarrierPidgeon.EventDriven;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System.IO;

namespace CarrierPidgeon
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true)
                .Build();

            var serviceProvider = new ServiceCollection()
                .ConfigureOptions(config)
                .AddSingleton<INotificationSender>(ns =>
                {
                    var conn = config.GetSection("Configuration:NotificationConnection").Value;
                    return new DefaultNotifiationSender(new MongoClient(conn));
                })
                .AddSingleton<IBatchDrivenInterfaceManager, BatchDrivenInterfaceManager>()
                .AddSingleton<IEventDrivenInterfaceManager, EventDrivenInterfaceManager>()
                .AddSingleton<IStartup, Startup>()
                .BuildServiceProvider();

            var startup = serviceProvider.GetService<IStartup>();
            startup.Start();
        }
    }
}
