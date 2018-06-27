using Apache.NMS;
using Apache.NMS.ActiveMQ;
using CarrierPidgeon.Component.ActiveMQ;
using CarrierPidgeon.Core.Events;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace CarrierPidgeon.Test.CarrierPidgeon.Component.ActiveMQ
{
    public class ActiveMQListener_Tests
    {
        [Fact]
        [Trait("Category", "unit")]
        public void ReceiveMessage()
        {
            //Assemble
            List<EventMessage> messages = new List<EventMessage>();

            var consumerMock = new Mock<IMessageConsumer>();
            var consumer = consumerMock.Object;

            var connectionMock = new Mock<IActiveMQConnection>();
            connectionMock.Setup(c => c.GetConsumer())
                .Returns(consumer);

            var listener = new ActiveMQListener(connectionMock.Object);
            listener.MessageReceived += (EventMessage eventMessage) => messages.Add(eventMessage);

            var objMsg = new Mock<IObjectMessage>();

            //Act
            consumerMock.Raise(c => c.Listener += null, objMsg.Object);

            //Assert
            Assert.Single(messages);
        }

        [Fact]
        [Trait("Category", "unit")]
        public void SendMessage()
        {
            //Assemble
            var callCount = 0;
            var producerMock = new Mock<IMessageProducer>();
            producerMock.Setup(p => p.Send(It.IsAny<IMessage>()))
                .Callback(() => callCount++);

            var connectionMock = new Mock<IActiveMQConnection>();
            connectionMock.Setup(c => c.GetProducer())
                .Returns(producerMock.Object);

            var publisher = new ActiveMQPublisher(connectionMock.Object);

            var message = new EventMessage();

            //Act
            publisher.SendMessage(message);

            //Assert
            Assert.Equal(1, callCount);

        }
    }
}