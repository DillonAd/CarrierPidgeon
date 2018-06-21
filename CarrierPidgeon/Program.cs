using CarrierPidgeon.BatchDriven;
using CarrierPidgeon.EventDriven;
using Microsoft.Extensions.DependencyInjection;

namespace CarrierPidgeon
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IBatchDrivenInterfaceManager, BatchDrivenInterfaceManager>()
                .AddSingleton<IEventDrivenInterfaceManager, EventDrivenInterfaceManager>()
                .AddSingleton<IStartup, Startup>()
                .BuildServiceProvider();

            var startup = serviceProvider.GetService<IStartup>();
            startup.Start();
        }
    }
}
