using CarrierPidgeon.Core;
using CarrierPidgeon.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CarrierPidgeon
{
    public sealed class Startup : IStartup
    {
        private readonly IFileHandler _fileHandler;
        private readonly IBatchDrivenInterfaceManager _scheduler;
        private readonly IEventDrivenInterfaceManager _eventDrivenInterfaceManager;

        public Startup(IFileHandler fileHandler, IBatchDrivenInterfaceManager scheduler, IEventDrivenInterfaceManager eventDrivenInterfaceManager)
        {
            _fileHandler = fileHandler;
            _scheduler = scheduler;
            _eventDrivenInterfaceManager = eventDrivenInterfaceManager;
        }

        public void Start()
        {
            Assembly assembly;

            foreach (string dllFile in _fileHandler.GetDllFiles())
            {
                assembly = Assembly.LoadFile(dllFile);
                var types = assembly.GetTypes().Where(t => t.IsAssignableFrom(typeof(IInterfaceComponent))
                    && !t.IsInterface
                    && !t.IsAbstract).ToList();

                AddTypes(types);
            }

            _eventDrivenInterfaceManager.Start();
            _scheduler.Start();
        }

        public void Dispose()
        {
            _scheduler.Dispose();
        }

        private void AddTypes(IEnumerable<Type> types)
        {
            IBatchDriven batchDrivenInterface;
            IEventDriven eventDriveInterface;

            foreach (var type in types)
            {
                if (type.IsAssignableFrom(typeof(IBatchDriven)))
                {
                    batchDrivenInterface = (IBatchDriven)Activator.CreateInstance(type);
                    _scheduler.Add(batchDrivenInterface);
                }
                else if (type.IsAssignableFrom(typeof(IEventDriven)))
                {
                    eventDriveInterface = (IEventDriven)Activator.CreateInstance(type);
                    _eventDrivenInterfaceManager.Add(eventDriveInterface);
                }
            }
        }
    }
}
