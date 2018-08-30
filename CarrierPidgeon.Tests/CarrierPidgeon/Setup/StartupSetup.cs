using CarrierPidgeon.BatchDriven;
using CarrierPidgeon.Core;
using CarrierPidgeon.Core.BatchDriven;
using CarrierPidgeon.Core.EventDriven;
using CarrierPidgeon.EventDriven;
using CarrierPidgeon.InterfaceLoad;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarrierPidgeon.Test.CarrierPidgeon.Setup
{
    public class StartupSetup
    {
        private readonly List<IBatchDriven<ISender<IEntity>, IBatchDrivenReceiver<IEntity>>> _batchDrivenInterfaces;
        private readonly List<IEventDriven<ISender<IEntity>, IEventDrivenReceiver<IEntity>>> _eventDrivenInterfaces;
        private readonly List<string> _files;
        public readonly List<Type> _types;

        private readonly Mock<IBatchDrivenInterfaceManager> _batchDrivenInterfaceManagerMock;
        public IBatchDrivenInterfaceManager BatchDrivenInterfaceManager => _batchDrivenInterfaceManagerMock.Object;

        private readonly Mock<IEventDrivenInterfaceManager> _eventDrivenInterfaceManagerMock;
        public IEventDrivenInterfaceManager EventDrivenInterfaceManager => _eventDrivenInterfaceManagerMock.Object;

        private readonly Mock<IFileSystem> _fileSystemMock;
        public IFileSystem FileSystem => _fileSystemMock.Object;

        private readonly Mock<IAssemblyInfo> _assemblyInfoMock;
        public IAssemblyInfo AssemblyInfo => _assemblyInfoMock.Object;

        public StartupSetup()
        {
            _batchDrivenInterfaces = new List<IBatchDriven<ISender<IEntity>, IBatchDrivenReceiver<IEntity>>>();
            _eventDrivenInterfaces = new List<IEventDriven<ISender<IEntity>, IEventDrivenReceiver<IEntity>>>();
            _files = new List<string>();
            _types = new List<Type>();

            _batchDrivenInterfaceManagerMock = new Mock<IBatchDrivenInterfaceManager>();
            _eventDrivenInterfaceManagerMock = new Mock<IEventDrivenInterfaceManager>();
            _fileSystemMock = new Mock<IFileSystem>();
            _assemblyInfoMock = new Mock<IAssemblyInfo>();

            _batchDrivenInterfaceManagerMock
                .Setup(b => b.Add(It.IsAny<IBatchDriven<ISender<IEntity>, IBatchDrivenReceiver<IEntity>>>()))
                    .Callback((IBatchDriven<ISender<IEntity>, IBatchDrivenReceiver<IEntity>> bd) => _batchDrivenInterfaces.Add(bd));
            
            _batchDrivenInterfaceManagerMock
                .Setup(b => b.Interfaces)
                    .Returns(_batchDrivenInterfaces);

            _eventDrivenInterfaceManagerMock
                .Setup(b => b.Add(It.IsAny<IEventDriven<ISender<IEntity>, IEventDrivenReceiver<IEntity>>>()))
                    .Callback((IEventDriven<ISender<IEntity>, IEventDrivenReceiver<IEntity>> ed) => _eventDrivenInterfaces.Add(ed));
            
            _eventDrivenInterfaceManagerMock
                .Setup(e => e.Interfaces)
                    .Returns(_eventDrivenInterfaces);

            _fileSystemMock.Setup(fs => fs.GetDllFiles()).Returns(_files);

            _assemblyInfoMock.Setup(ai => ai.GetInterfaceType(It.IsAny<string>()))
                .Returns(() => {
                    return _types.FirstOrDefault();
                });
        }

        public void AddFile(string fileName) => _files.Add(fileName);

        public void AddType(Type type) => _types.Add(type);
    }
}
