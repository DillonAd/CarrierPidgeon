using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Transport;
using CarrierPidgeon.Core;
using System;

namespace CarrierPidgeon.Interfaces.ActiveMQ
{
    public class ActiveMQListener : EventDrivenInterface
    {
        private readonly IConnection _connection;

        public ActiveMQListener(IConnection connection)
        {
            _connection = connection;
        }
    }
}
