using CarrierPidgeon.Test.CarrierPidgeon.Setup;
using CarrierPidgeon.Test.CarrierPidgeon.Types;
using System.Threading;
using Xunit;

namespace CarrierPidgeon.Test.CarrierPidgeon
{
    public class Startup_Tests
    {
        [Fact]
        [Trait("Category", "unit")]
        public void Start_BatchDriven_Success()
        {
            //Assemble
            var setup = new StartupSetup();
            setup.AddFile("testfile.dll");
            setup.AddType(typeof(TestBatchDrivenInterface));

            var startup = new Startup(
                setup.BatchDrivenInterfaceManager, 
                setup.EventDrivenInterfaceManager,
                setup.FileSystem,
                setup.AssemblyInfo);

            var tokenSource = new CancellationTokenSource();

            //Act
            startup.StartAsync(tokenSource.Token);

            //Assert
            Assert.Single(setup.BatchDrivenInterfaceManager.Interfaces);
        }

        [Fact]
        [Trait("Category", "unit")]
        public void Start_EventDriven_Success()
        {
            //Assemble
            var setup = new StartupSetup();
            setup.AddFile("testfile.dll");
            setup.AddType(typeof(TestEventDrivenInterface));

            var startup = new Startup(
                setup.BatchDrivenInterfaceManager, 
                setup.EventDrivenInterfaceManager,
                setup.FileSystem,
                setup.AssemblyInfo);
            
            var tokenSource = new CancellationTokenSource();

            //Act
            startup.StartAsync(tokenSource.Token);

            //Assert
            Assert.Single(setup.EventDrivenInterfaceManager.Interfaces);
        }
    }
}
