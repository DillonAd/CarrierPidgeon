using CarrierPidgeon.BatchDriven;
using CarrierPidgeon.Core;
using CarrierPidgeon.Core.BatchDriven;
using CarrierPidgeon.Core.EventDriven;
using CarrierPidgeon.EventDriven;
using CarrierPidgeon.InterfaceLoad;
using System.Collections.Generic;

namespace CarrierPidgeon
{
    public sealed class Startup : IStartup
    {
        public IEnumerable<IBatchDriven<IBatchDrivenSender, IBatchDrivenReceiver>> BatchDrivenInterfaces => _batchDrivenInterfaceManager.Interfaces;
        public IEnumerable<IEventDriven<IEventDrivenSender, IEventDrivenReceiver>> EventDrivenInterfaces => _eventDrivenInterfaceManager.Interfaces;

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
            IBatchDriven<IBatchDrivenSender, IBatchDrivenReceiver> batchDrivenInterface;
            IEventDriven<IEventDrivenSender, IEventDrivenReceiver> eventDrivenInterface;

            foreach (var @interface in interfaces)
            {
                if (typeof(IBatchDriven<IBatchDrivenSender, IBatchDrivenReceiver>).IsAssignableFrom(@interface.Type))
                {
                    batchDrivenInterface = @interface.CreateInstance<IBatchDriven<IBatchDrivenSender, IBatchDrivenReceiver>>();
                    _batchDrivenInterfaceManager.Add(batchDrivenInterface);
                }
                else if (typeof(IEventDriven<IEventDrivenSender, IEventDrivenReceiver>).IsAssignableFrom(@interface.Type))
                {
                    eventDrivenInterface = @interface.CreateInstance<IEventDriven<IEventDrivenSender, IEventDrivenReceiver>>();
                    _eventDrivenInterfaceManager.Add(eventDrivenInterface);
                }
            }
        }
    }
}
