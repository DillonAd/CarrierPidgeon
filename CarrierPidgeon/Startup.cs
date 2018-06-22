using CarrierPidgeon.BatchDriven;
using CarrierPidgeon.Core;
using CarrierPidgeon.EventDriven;
using CarrierPidgeon.InterfaceLoad;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CarrierPidgeon
{
    public sealed class Startup : IStartup
    {
        public IEnumerable<IBatchDriven<ISender, IReceiver>> BatchDrivenInterfaces => _batchDrivenInterfaceManager.Interfaces;
        public IEnumerable<IEventDriven<ISender, IEventDrivenReceiver>> EventDrivenInterfaces => _eventDrivenInterfaceManager.Interfaces;

        private readonly IBatchDrivenInterfaceManager _batchDrivenInterfaceManager;
        private readonly IEventDrivenInterfaceManager _eventDrivenInterfaceManager;
        private readonly IFileSystem _fileSystem;
        private readonly IAssemblyInfo _assemblyInfo;

        public Startup(
            IBatchDrivenInterfaceManager batchDrivenInterfaceManager,
            IEventDrivenInterfaceManager eventDrivenInterfaceManager,
            IFileSystem fileSystem,
            IAssemblyInfo assemblyInfo)
        {
            _batchDrivenInterfaceManager = batchDrivenInterfaceManager;
            _eventDrivenInterfaceManager = eventDrivenInterfaceManager;
            _fileSystem = fileSystem;
            _assemblyInfo = assemblyInfo;
        }

        public void Start()
        {
            var dllFiles = _fileSystem.GetDllFiles();
            var interfaces = new List<Interface>();

            foreach (var file in dllFiles)
            {
                var type = _assemblyInfo.GetInterfaceType(file);
                interfaces.Add(new Interface(type));
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
                    batchDrivenInterface = @interface.CreateInstance<IBatchDriven<ISender, IReceiver>>();
                    _batchDrivenInterfaceManager.Add(batchDrivenInterface);
                }
                else if (@interface.Type.IsAssignableFrom(typeof(IEventDriven<ISender, IEventDrivenReceiver>)))
                {
                    eventDrivenInterface = @interface.CreateInstance<IEventDriven<ISender, IEventDrivenReceiver>>();
                    _eventDrivenInterfaceManager.Add(eventDrivenInterface);
                }
            }
        }
    }
}
