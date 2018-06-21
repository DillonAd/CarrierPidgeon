using CarrierPidgeon.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CarrierPidgeon
{
    public sealed class Startup : IStartup
    {
        private readonly IBatchDrivenInterfaceManager _batchDrivenInterfaceManager;
        private readonly IEventDrivenInterfaceManager _eventDrivenInterfaceManager;

        public Startup(IBatchDrivenInterfaceManager batchDrivenInterfaceManager, IEventDrivenInterfaceManager eventDrivenInterfaceManager)
        {
            _batchDrivenInterfaceManager = batchDrivenInterfaceManager;
            _eventDrivenInterfaceManager = eventDrivenInterfaceManager;
        }

        public void Start()
        {
            var path = Assembly.GetExecutingAssembly().Location;
            var dllFiles = Directory.GetFiles(path, "*.dll");

            List<Interface> interfaces = new List<Interface>();

            foreach (var file in dllFiles)
            {
                interfaces.Add(new Interface(file));
            }

            AddInterfaces(interfaces);

            _eventDrivenInterfaceManager.Start();
            _batchDrivenInterfaceManager.Start();
        }

        public void Dispose()
        {
            _batchDrivenInterfaceManager.Dispose();
        }

        private void AddInterfaces(IEnumerable<Interface> interfaces)
        {
            IBatchDriven<ISender, IReceiver> batchDrivenInterface;
            IEventDriven<ISender, IEventDrivenReceiver> eventDrivenInterface;

            foreach (var @interface in interfaces)
            {
                if (@interface.Type.IsAssignableFrom(typeof(IBatchDriven<ISender, IReceiver>)))
                {
                    batchDrivenInterface = (IBatchDriven<ISender, IReceiver>)@interface.Instance;
                    _batchDrivenInterfaceManager.Add(batchDrivenInterface);
                }
                else if (@interface.Type.IsAssignableFrom(typeof(IEventDriven<ISender, IEventDrivenReceiver>)))
                {
                    eventDrivenInterface = (IEventDriven<ISender, IEventDrivenReceiver>)@interface.Instance;
                    _eventDrivenInterfaceManager.Add(eventDrivenInterface);
                }
            }
        }
    }
}
