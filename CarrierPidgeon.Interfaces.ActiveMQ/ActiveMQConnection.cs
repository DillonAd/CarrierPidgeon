using Apache.NMS;
using System;

namespace CarrierPidgeon.Interfaces.ActiveMQ
{
    public class ActiveMQConnection : IActiveMQConnection
    {
        private readonly IConnection _connection;
        private readonly ISession _session;
        private readonly IDestination _destination;

        public ActiveMQConnection(Uri uri, string destinationName) : this(uri, destinationName, string.Empty, string.Empty) { }

        public ActiveMQConnection(Uri uri, string destinationName, string userName, string password)
        {
            var connectionFactory = NMSConnectionFactory.CreateConnectionFactory(uri);
            _connection = connectionFactory.CreateConnection(userName, password);
            _session = _connection.CreateSession();
            _destination = _session.GetDestination(destinationName);
        }

        public void Open()
        {
            _connection.Start();
        }

        public void Close()
        {
            _connection.Stop();
        }

        public void Dispose()
        {
            _session.Dispose();
            _connection.Dispose();
        }

        public IMessageProducer GetProducer()
        {
            return _session.CreateProducer(_destination);
        }

        public IMessageConsumer GetConsumer()
        {
            return _session.CreateConsumer(_destination);
        }

        public IObjectMessage CreateObjectMessage(object obj)
        {
            return _session.CreateObjectMessage(obj);
        }
    }
}
