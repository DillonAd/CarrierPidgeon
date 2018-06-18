using CarrierPidgeon.Core;
using CarrierPidgeon.Files;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CarrierPidgeon
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IScheduler, Scheduler>()
                .AddTransient<IFileHandler, FileHandler>()
                .AddTransient<IStartup, Startup>()
                .BuildServiceProvider();

            var startup = serviceProvider.GetService<IStartup>();
            startup.Start();
        }
    }
}
