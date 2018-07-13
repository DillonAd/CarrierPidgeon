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
        public IEnumerable<IBatchDriven<ISender<IEntity>, IBatchDrivenReceiver<IEntity>>> BatchDrivenInterfaces => _batchDrivenInterfaceManager.Interfaces;
        public IEnumerable<IEventDriven<ISender<IEntity>, IEventDrivenReceiver<IEntity>>> EventDrivenInterfaces => _eventDrivenInterfaceManager.Interfaces;

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
            IBatchDriven<ISender<IEntity>, IBatchDrivenReceiver<IEntity>> batchDrivenInterface;
            IEventDriven<ISender<IEntity>, IEventDrivenReceiver<IEntity>> eventDrivenInterface;

            foreach (var @interface in interfaces)
            {
                if (typeof(IBatchDriven<ISender<IEntity>, IBatchDrivenReceiver<IEntity>>).IsAssignableFrom(@interface.Type))
                {
                    batchDrivenInterface = @interface.CreateInstance<IBatchDriven<ISender<IEntity>, IBatchDrivenReceiver<IEntity>>>();
                    _batchDrivenInterfaceManager.Add(batchDrivenInterface);
                }
                else if (typeof(IEventDriven<ISender<IEntity>, IEventDrivenReceiver<IEntity>>).IsAssignableFrom(@interface.Type))
                {
                    eventDrivenInterface = @interface.CreateInstance<IEventDriven<ISender<IEntity>, IEventDrivenReceiver<IEntity>>>();
                    _eventDrivenInterfaceManager.Add(eventDrivenInterface);
                }
            }
        }
    }
}
