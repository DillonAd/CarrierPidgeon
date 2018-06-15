using Apache.NMS;
using CarrierPidgeon.Core;
using CarrierPidgeon.Core.Events;
using System;

namespace CarrierPidgeon.Interfaces.ActiveMQ
{
    public class ActiveMQListener : IEventDrivenReceiver
    {
        private readonly IConnection _connection;
        private readonly ISession _session;
        private readonly IDestination _destination;
        
        private IMessageProducer _producer;
        private IMessageConsumer _consumer;

        public event OnMessageReceived MessageReceived;

        public ActiveMQListener(Uri uri, string destinationName) : this(uri, destinationName, string.Empty, string.Empty) { }

        public ActiveMQListener(Uri uri, string destinationName, string userName, string password)
        {
            var connectionFactory = NMSConnectionFactory.CreateConnectionFactory(uri);
            _connection = connectionFactory.CreateConnection(userName, password);
            _session = _connection.CreateSession();
            _destination = _session.GetDestination(destinationName);
            _consumer = _session.CreateConsumer(_destination);
            _consumer.Listener += OnMessage;
        }

        public void OnMessage<IMessage>(IMessage message)
        {
            ITextMessage msg = (ITextMessage)message;
            var eventMessage = new EventMessage(msg.Text);

            MessageReceived(eventMessage);
        }

        public void Dispose()
        {
            _consumer.Dispose();
            _destination.Dispose();
            _session.Dispose();
            _connection.Dispose();
        }
    }
}
