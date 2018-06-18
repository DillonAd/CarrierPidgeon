using CarrierPidgeon.Core;
using CarrierPidgeon.Files;
using System;
using System.Linq;
using System.Reflection;

namespace CarrierPidgeon
{
    public class Startup : IStartup
    {
        private readonly IFileHandler _fileHandler;
        private readonly IScheduler _scheduler;

        public Startup(IFileHandler fileHandler, IScheduler scheduler)
        {
            _fileHandler = fileHandler;
            _scheduler = scheduler;
        }

        public void Start()
        {
            Assembly assembly;

            foreach (string dllFile in _fileHandler.GetDllFiles())
            {
                assembly = Assembly.LoadFile(dllFile);
                var types = assembly.GetTypes().Where(t => t.IsAssignableFrom(typeof(IBatchDriven))
                    && !t.IsInterface
                    && !t.IsAbstract).ToList();

                foreach (var type in types)
                {
                    if (type.IsAssignableFrom(typeof(IBatchDriven)))
                    {
                        var batchedInterface = (IBatchDriven)Activator.CreateInstance(type);
                        _scheduler.Add(batchedInterface);
                    }
                }
            }
        }

        public void Dispose()
        {
            _scheduler.Dispose();
        }
    }
}
