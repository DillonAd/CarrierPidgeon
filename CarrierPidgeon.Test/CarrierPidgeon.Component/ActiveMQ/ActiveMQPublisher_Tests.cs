using Apache.NMS;
using CarrierPidgeon.Component.ActiveMQ;
using CarrierPidgeon.Core.EventDriven;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace CarrierPidgeon.Test.CarrierPidgeon.Component.ActiveMQ
{
    public class ActiveMQPublisher_Tests
    {
        [Fact]
        [Trait("Category", "unit")]
        public void SendMessage()
        {
            //Assemble
            List<IMessage> messages = new List<IMessage>();

            var publisherMock = new Mock<IMessageProducer>();
            publisherMock.Setup(p => p.Send(It.IsAny<IMessage>()))
                .Callback((IMessage msg) => messages.Add(msg));
            var publisher = publisherMock.Object;

            var connectionMock = new Mock<IActiveMQConnection>();
            connectionMock.Setup(c => c.GetProducer())
                .Returns(publisher);

            var producer = new ActiveMQPublisher(connectionMock.Object);

            var eventMessage = new EventMessage();

            //Act
            producer.Send(eventMessage);

            //Assert
            Assert.Single(messages);
        }
    }
}