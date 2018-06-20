using CarrierPidgeon.Core;
using Moq;
using System.Linq;
using Xunit;

namespace CarrierPidgeon.Test.CarrierPidgeon
{
    public class BatchDrivenInterfaceManager_Tests
    {
        [Fact]
        [Trait("Category", "unit")]
        public void AddInterface()
        {
            //Assemble
            var bdi = new Mock<IBatchDriven>().Object;
            var manager = new BatchDrivenInterfaceManager();

            //Act
            manager.Add(bdi);

            //Assert
            Assert.Single(manager.Interfaces);
        }

        [Fact]
        [Trait("Category", "unit")]
        public void ExecuteInterface()
        {
            //Assemble
            var mock = new Mock<IBatchDriven>();
            mock.Setup(i => i.Execute())
                .Callback(() => mock.SetupGet(p => p.IsExecuting).Returns(true));

            var manager = new BatchDrivenInterfaceManager();
            manager.Add(mock.Object);

            //Act
            manager.Start();

            //Assert
            Assert.True(manager.Interfaces.FirstOrDefault().IsExecuting);
        }
    }
}
