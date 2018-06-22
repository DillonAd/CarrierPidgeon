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
        public IBatchDrivenInterfaceManager
        public IStartup Setup()
        {
            var batchDrivenInterfaceManagerMock = new Mock<IBatchDrivenInterfaceManager>();
            var eventDrivenInterfaceManagerMock = new Mock<IEventDrivenInterfaceManager>();
            var fileSystemMock = new Mock<IFileSystem>();
            var assemblyInfoMock = new Mock<IAssemblyInfo>();

            var batchDrivenInterfaceCollection = new List<IBatchDriven<ISender, IReceiver>>();
            batchDrivenInterfaceManagerMock
                .Setup(b => b.Add(It.IsAny<IBatchDriven<ISender, IReceiver>>()))
                .Callback((IBatchDriven<ISender, IReceiver> bd) => batchDrivenInterfaceCollection.Add(bd));

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
