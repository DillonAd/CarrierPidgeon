using CarrierPidgeon.Files;
using Microsoft.Extensions.DependencyInjection;

namespace CarrierPidgeon
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IBatchDrivenInterfaceManager, BatchDrivenInterfaceManager>()
                .AddTransient<IFileHandler, FileHandler>()
                .AddTransient<IStartup, Startup>()
                .BuildServiceProvider();

            var startup = serviceProvider.GetService<IStartup>();
            startup.Start();
        }
    }
}
