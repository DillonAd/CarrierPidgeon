using Apache.NMS;
using CarrierPidgeon.Core;
using CarrierPidgeon.Core.EventDriven;
using System;

namespace CarrierPidgeon.Component.ActiveMQ
{
    public class ActiveMQListener<TReceiveType> : IEventDrivenReceiver<TReceiveType>
        where TReceiveType : IEntity
    {
        private readonly IInterfaceConnection _connection;
        private readonly IMessageConsumer _consumer;

        public event OnMessageReceived MessageReceived;

        public ActiveMQListener(IActiveMQConnection connection)
        {
            _connection = connection;
            _consumer = connection.GetConsumer();
            _consumer.Listener += OnMessage;
        }

        private void OnMessage<IMessage>(IMessage t)
        {
            IObjectMessage msg = t as IObjectMessage;
            var eventMessage = new EventMessage(msg.Body);

            MessageReceived(eventMessage);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _consumer.Dispose();
            _connection.Dispose();
        }
    }
}
