﻿using Apache.NMS;
using CarrierPidgeon.Core;
using CarrierPidgeon.Core.EventDriven;
using System;

namespace CarrierPidgeon.Component.ActiveMQ
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

        public void SendMessage(EventMessage message)
        {
            var msg = ((IActiveMQConnection)_connection).CreateObjectMessage(message);
            _producer.Send(msg);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _producer.Dispose();
            _connection.Dispose();
        }
    }
}
