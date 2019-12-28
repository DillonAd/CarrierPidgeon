using CarrierPidgeon.BatchDriven;
using CarrierPidgeon.InterfaceLoad;
using CarrierPidgeon.Core.Notifications;
using CarrierPidgeon.EventDriven;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace CarrierPidgeon
{
    public static class Program
    {
        public async static Task Main(string[] args)
        {
            var hostBuilder = new HostBuilder()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;

                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddTransient<IAssemblyInfo, AssemblyInfo>()
                            .AddSingleton<INotificationSender, DefaultNotifiationSender>()
                            .AddTransient<IFileSystem, FileSystem>()
                            .AddSingleton<IBatchDrivenInterfaceManager, BatchDrivenInterfaceManager>()
                            .AddSingleton<IEventDrivenInterfaceManager, EventDrivenInterfaceManager>()
                            .AddSingleton<IHostedService, Startup>();
                });

            await hostBuilder.RunConsoleAsync();
        }
    }
}
