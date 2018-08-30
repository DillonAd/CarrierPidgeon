using CarrierPidgeon.Test.CarrierPidgeon.Setup;
using CarrierPidgeon.Test.CarrierPidgeon.Types;
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
            var fixture = new StartupSetup();
            fixture.AddFile("testfile.dll");
            fixture.AddType(typeof(TestBatchDrivenInterface));

            //Act
            var startup = new Startup(
                fixture.BatchDrivenInterfaceManager, 
                fixture.EventDrivenInterfaceManager,
                fixture.FileSystem,
                fixture.AssemblyInfo);
            
            startup.Start();

            //Assert
            Assert.Single(fixture.BatchDrivenInterfaceManager.Interfaces);
        }

        [Fact]
        [Trait("Category", "unit")]
        public void Start_EventDriven_Success()
        {
            //Assemble
            var setup = new StartupSetup();
            setup.AddFile("testfile.dll");
            setup.AddType(typeof(TestEventDrivenInterface));

            //Act
            var startup = new Startup(
                setup.BatchDrivenInterfaceManager, 
                setup.EventDrivenInterfaceManager,
                setup.FileSystem,
                setup.AssemblyInfo);
            
            startup.Start();

            //Assert
            Assert.Single(setup.EventDrivenInterfaceManager.Interfaces);
        }
    }
}
