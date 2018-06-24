using CarrierPidgeon.BatchDriven;
using CarrierPidgeon.Core;
using CarrierPidgeon.EventDriven;
using CarrierPidgeon.InterfaceLoad;
using CarrierPidgeon.Test.CarrierPidgeon.Fixtures;
using CarrierPidgeon.Test.CarrierPidgeon.Types;
using Moq;
using System;
using System.Collections.Generic;
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
            var fixture = new StartupFixture();
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
    }
}
