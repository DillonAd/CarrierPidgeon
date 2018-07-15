using CarrierPidgeon.Component.SqlServer;
using CarrierPidgeon.Core;
using Moq;
using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace CarrierPidgeon.Test.CarrierPidgeon.Component.SqlServer
{
    public class SqlServerPublisher_Tests
    {
        [Fact]
        [Trait("Category", "unit")]
        public void Send_Success()
        {
            //Assemble
            var parameters = new List<object>();
            var executeCount = 0;

            var sqlConnMock = new Mock<ISqlServerConnection>();
            var sqlCmdMock = new Mock<ISqlServerCommand>();
            sqlCmdMock.Setup(s => s.Execute())
                .Callback(() => executeCount++);

            var sut = new SqlServerSender<IEntity>(sqlConnMock.Object, sqlCmdMock.Object);

            var msgMock = new Mock<IEntity>();

            //Act
            sut.Send(msgMock.Object);

            //Assert
            Assert.Equal(1, executeCount);
        }

        [Fact]
        [Trait("Category", "unit")]
        public void AddParameter_Multiple_Success()
        {
            //Assemble
            var parameters = new List<object>();
            var executeCount = 0;

            var sqlConnMock = new Mock<ISqlServerConnection>();
            var sqlCmdMock = new Mock<ISqlServerCommand>();
            sqlCmdMock.Setup(s => s.AddParameter(It.IsAny<string>(), It.IsAny<object>()))
                .Callback((string name, object value) => parameters.Add(value));

            sqlCmdMock.Setup(s => s.Execute())
                .Callback(() => executeCount++);

            var inputParams = new object[]
            {
                "test",
                1,
                1.0001,
                false,
                'a',
                DateTime.Now
            };

            var sut = new SqlServerSender<IEntity>(sqlConnMock.Object, sqlCmdMock.Object);

            var testEntity = new TestEntity();
            var propertyCount = testEntity.GetType().GetProperties().Length;

            //Act
            sut.Send(testEntity);

            //Assert
            Assert.Equal(2, propertyCount);
        }

        class TestEntity : IEntity
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}