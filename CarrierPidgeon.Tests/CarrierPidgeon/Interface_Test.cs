using CarrierPidgeon.Core;
using CarrierPidgeon.Core.BatchDriven;
using CarrierPidgeon.InterfaceLoad;
using CarrierPidgeon.Test.CarrierPidgeon.Types;
using System;
using Xunit;

namespace CarrierPidgeon.Test.CarrierPidgeon
{
    public class Interface_Test
    {
        [Fact]
        [Trait("Category", "unit")]
        public void Create_Interface_Instance()
        {
            //Assemble
            Type type = typeof(TestBatchDrivenInterface);

            //Act
            var @interface = new Interface(type);
            var instance = @interface.CreateInstance<IBatchDriven<ISender<IEntity>, IBatchDrivenReceiver<IEntity>>>();
            
            //Assert
            Assert.NotNull(instance);
        }

        [Fact]
        [Trait("Category", "unit")]
        public void Create_Interface_With_Type_That_Doesnt_Implement_IInterface()
        {
            //Assemble
            //Act
            //Assert
            Assert.Throws<InvalidCastException>(() => new Interface(typeof(AssemblyInfo)));
        }
    }
}