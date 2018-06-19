﻿using Apache.NMS;
using CarrierPidgeon.Core;
using CarrierPidgeon.Core.Events;
using System;

namespace CarrierPidgeon.Interfaces.ActiveMQ
{
    public class ActiveMQListener : IEventDrivenReceiver
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

        public void OnMessage<IMessage>(IMessage t)
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
