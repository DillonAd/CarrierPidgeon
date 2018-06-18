using Apache.NMS;
using CarrierPidgeon.Core;
using CarrierPidgeon.Core.Events;
using System;

namespace CarrierPidgeon.Interfaces.ActiveMQ
{
    public class ActiveMQPublisher : ISender
    {
        private readonly IInterfaceConnection _connection;
        private readonly IMessageProducer _producer;

        public ActiveMQPublisher(IActiveMQConnection connection)
        {
            _connection = connection;
            _producer = connection.GetProducer();
        }

        public void SendMessage(EventMessage eventMessage)
        {
            var msg = ((IActiveMQConnection)_connection).CreateObjectMessage(eventMessage);
            _producer.Send(msg);
        }

        public void Dispose()
        {
            _producer.Dispose();
        }
    }
}
