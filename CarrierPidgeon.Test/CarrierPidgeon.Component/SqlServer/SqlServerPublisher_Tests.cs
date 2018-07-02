using CarrierPidgeon.Component.SqlServer;
using Moq;
using System.Collections.Generic;
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

            var sut = new SqlServerSender(sqlConnMock.Object, sqlCmdMock.Object);

            //Act
            sut.Push();

            //Assert
            Assert.Equal(1, executeCount);
        }

        [Fact]
        [Trait("Category", "unit")]
        public void AddParameter_Success()
        {
            //Assemble
            var parameters = new List<object>();
            var executeCount = 0;

            var sqlConnMock = new Mock<ISqlServerConnection>();
            var sqlCmdMock = new Mock<ISqlServerCommand>();
            sqlCmdMock.Setup(s => s.AddParameter(It.IsAny<object>()))
                .Callback((object obj) => parameters.Add(obj));

            sqlCmdMock.Setup(s => s.Execute())
                .Callback(() => executeCount++);

            var sut = new SqlServerSender(sqlConnMock.Object, sqlCmdMock.Object);

            //Act
            sut.Push();

            //Assert
            Assert.Equal(1, executeCount);
        }
    }
}