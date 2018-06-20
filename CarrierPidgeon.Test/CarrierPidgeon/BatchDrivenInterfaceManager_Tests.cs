using CarrierPidgeon.Core;
using Moq;
using System;
using System.Linq;
using System.Threading;
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
        public void ExecuteInterface_Success()
        {
            using (var manager = new BatchDrivenInterfaceManager())
            {
                //Assemble
                var mock = new Mock<IBatchDriven>();
                mock.SetupGet(p => p.NextExecutionTime)
                    .Returns(DateTime.Now.AddSeconds(-10000));
                mock.Setup(i => i.Execute())
                    .Callback(() => mock.SetupGet(p => p.IsExecuting).Returns(true));

                manager.Add(mock.Object);

                //Act
                manager.Start();

                //Assert
                Thread.Sleep(1000);
                Assert.True(manager.Interfaces.FirstOrDefault().IsExecuting);
            }
        }

        [Fact]
        [Trait("Category", "unit")]
        public void ExecuteInterface_DoNotExecuteIfNextExecutionTimeGreaterThanCurrentTime()
        {
            using (var manager = new BatchDrivenInterfaceManager())
            {
                //Assemble
                var mock = new Mock<IBatchDriven>();
                mock.SetupGet(p => p.NextExecutionTime)
                    .Returns(DateTime.Now.AddSeconds(10000));
                mock.Setup(i => i.Execute())
                    .Callback(() => mock.SetupGet(p => p.IsExecuting).Returns(true));

                manager.Add(mock.Object);

                //Act
                manager.Start();

                //Assert
                Thread.Sleep(1000);
                Assert.False(manager.Interfaces.FirstOrDefault().IsExecuting);
            }
        }
    }
}
