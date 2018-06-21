using CarrierPidgeon.Core;
using Moq;
using System.Linq;
using Xunit;

namespace CarrierPidgeon.Test.CarrierPidgeon
{
    public class EventDrivenInterfaceManager_Tests
    {
        [Fact]
        [Trait("Category", "unit")]
        public void AddInterface()
        {
            //Assemble
            var edi = new Mock<IEventDriven<ISender, IEventDrivenReceiver>>().Object;
            var manager = new EventDrivenInterfaceManager();

            //Act
            manager.Add(edi);

            //Assert
            Assert.Single(manager.Interfaces);
        }

        [Fact]
        [Trait("Category", "unit")]
        public void StartInterface()
        {
            //Assemble
            var mock = new Mock<IEventDriven<ISender, IEventDrivenReceiver>>();
            mock.Setup(i => i.Start())
                .Callback(() => mock.SetupGet(p => p.IsStarted).Returns(true));

            var manager = new EventDrivenInterfaceManager();
            manager.Add(mock.Object);

            //Act
            manager.Start();

            //Assert
            Assert.True(manager.Interfaces.FirstOrDefault().IsStarted);
        }

        [Fact]
        [Trait("Category", "unit")]
        public void StartInterfaces()
        {
            //Assemble
            var mock = new Mock<IEventDriven<ISender, IEventDrivenReceiver>>();
            mock.Setup(i => i.Start())
                .Callback(() => mock.SetupGet(p => p.IsStarted).Returns(true));

            var mock1 = new Mock<IEventDriven<ISender, IEventDrivenReceiver>>();
            mock1.Setup(i => i.Start())
                .Callback(() => mock1.SetupGet(p => p.IsStarted).Returns(true));

            var manager = new EventDrivenInterfaceManager();
            manager.Add(mock.Object);
            manager.Add(mock1.Object);

            //Act
            manager.Start();
            
            //Assert
            Assert.All(manager.Interfaces, i => Assert.True(i.IsStarted));
        }

        [Fact]
        [Trait("Category", "unit")]
        public void DisposeInterface()
        {
            //Assemble
            var mock = new Mock<IEventDriven<ISender, IEventDrivenReceiver>>();
            mock.Setup(i => i.Dispose())
                .Callback(() => mock.SetupGet(p => p.IsDisposed).Returns(true));

            var manager = new EventDrivenInterfaceManager();
            manager.Add(mock.Object);

            //Act
            manager.Dispose();

            //Assert
            Assert.True(manager.Interfaces.FirstOrDefault().IsDisposed);
        }

        [Fact]
        [Trait("Category", "unit")]
        public void DisposeInterfaces()
        {
            //Assemble
            var mock = new Mock<IEventDriven<ISender, IEventDrivenReceiver>>();
            mock.Setup(i => i.Dispose())
                .Callback(() => mock.SetupGet(p => p.IsDisposed).Returns(true));

            var mock1 = new Mock<IEventDriven<ISender, IEventDrivenReceiver>>();
            mock1.Setup(i => i.Dispose())
                .Callback(() => mock1.SetupGet(p => p.IsDisposed).Returns(true));

            var manager = new EventDrivenInterfaceManager();
            manager.Add(mock.Object);
            manager.Add(mock1.Object);

            //Act
            manager.Dispose();

            //Assert
            Assert.All(manager.Interfaces, i => Assert.True(i.IsDisposed));
        }
    }
}
