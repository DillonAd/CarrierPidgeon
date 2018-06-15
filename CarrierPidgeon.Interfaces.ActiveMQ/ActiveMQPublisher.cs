using Apache.NMS;
using CarrierPidgeon.Core;
using CarrierPidgeon.Core.Events;
using System;

namespace CarrierPidgeon.Interfaces.ActiveMQ
{
    public class ActiveMQPublisher : ISender
    {
        private readonly IConnection _connection;
        private readonly ISession _session;
        private readonly IDestination _destination;
        
        private IMessageProducer _producer;

        public ActiveMQPublisher(Uri uri, string destinationName) : this(uri, destinationName, string.Empty, string.Empty) { }

        public ActiveMQPublisher(Uri uri, string destinationName, string userName, string password)
        {
            var connectionFactory = NMSConnectionFactory.CreateConnectionFactory(uri);
            _connection = connectionFactory.CreateConnection(userName, password);
            _session = _connection.CreateSession();
            _destination = _session.GetDestination(destinationName);
            _producer = _session.CreateProducer(_destination);
        }

        public void SendMessage(EventMessage eventMessage)
        {
            var msg = _session.CreateObjectMessage(eventMessage);
            _producer.Send(msg);
        }

        public void Dispose()
        {
            _producer.Dispose();
            _destination.Dispose();
            _session.Dispose();
            _connection.Dispose();
        }
    }
}
