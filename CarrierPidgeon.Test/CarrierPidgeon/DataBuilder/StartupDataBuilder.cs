using CarrierPidgeon.BatchDriven;
using CarrierPidgeon.Core;
using CarrierPidgeon.EventDriven;
using CarrierPidgeon.InterfaceLoad;
using Moq;
using System.Collections.Generic;

namespace CarrierPidgeon.Test.CarrierPidgeon.Fixture
{
    public class StartupDataBuilder
    {
        private readonly List<IBatchDriven<ISender, IReceiver>> _batchDrivenInterfaces;
        private readonly List<IEventDriven<ISender, IEventDrivenReceiver>> _eventDrivenInterfaces;

        private readonly Mock<IBatchDrivenInterfaceManager> _batchDrivenInterfaceManagerMock;
        public IBatchDrivenInterfaceManager BatchDrivenInterfaceManager => _batchDrivenInterfaceManagerMock.Object;

        private readonly Mock<IEventDrivenInterfaceManager> _eventDrivenInterfaceManagerMock;
        public IEventDrivenInterfaceManager EventDrivenInterfaceManager => _eventDrivenInterfaceManagerMock.Object;

        private readonly Mock<IFileSystem> _fileSystemMock;
        public IFileSystem FileSystem => _fileSystemMock.Object;

        private readonly Mock<IAssemblyInfo> _assemblyInfo;
        public IAssemblyInfo AssemblyInfo => _assemblyInfo.Object;

        public StartupDataBuilder()
        {
            var batchDrivenInterfaceManagerMock = new Mock<IBatchDrivenInterfaceManager>();
            var eventDrivenInterfaceManagerMock = new Mock<IEventDrivenInterfaceManager>();
            var fileSystemMock = new Mock<IFileSystem>();
            var assemblyInfoMock = new Mock<IAssemblyInfo>();

            _batchDrivenInterfaceManagerMock
                .Setup(b => b.Add(It.IsAny<IBatchDriven<ISender, IReceiver>>()))
                .Callback((IBatchDriven<ISender, IReceiver> bd) => _batchDrivenInterfaces.Add(batchDrivenInterface));
            


        }

        public StartupDataBuilder AddBatchDrivenInterface(IBatchDriven<ISender, IReceiver> batchDrivenInterface)
        {
            
            return this;
        }

        public StartupDataBuilder AddEventDrivenInterface(IEventDriven<ISender, IEventDrivenReceiver> eventDrivenInterface)
        {
    
        }

        public IStartup Setup()
        {
            

            
            var eventDrivenInterfaceCollection = new List<IEventDriven<ISender, IEventDrivenReceiver>>();
            eventDrivenInterfaceManagerMock
                .Setup(b => b.Add(It.IsAny<IEventDriven<ISender, IEventDrivenReceiver>>()))
                .Callback((IEventDriven<ISender, IEventDrivenReceiver> ed) => eventDrivenInterfaceCollection.Add(ed));

            fileSystemMock.Setup(fs => fs.GetDllFiles())
                .Returns(new List<string>() { "file.dll" });

            assemblyInfoMock.Setup(a => a.GetInterfaceType(It.IsAny<string>()))
                .Returns(typeof(TestInterface));

            IStartup startup = new Startup(
                batchDrivenInterfaceManagerMock.Object,
                eventDrivenInterfaceManagerMock.Object,
                fileSystemMock.Object,
                assemblyInfoMock.Object);

            return startup;
        }

        public class TestInterface : IInterface<ISender, IReceiver>
        {
            public IReceiver Receiver { get; }

            public ISender Sender { get; }

            public void Dispose()
            {
                Receiver.Dispose();
                Sender.Dispose();
            }
        }
    }
}
