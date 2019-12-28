using Apache.NMS;
using CarrierPidgeon.Core;
using System;
using System.Threading.Tasks;

namespace CarrierPidgeon.Component.ActiveMQ
{
    public class ActiveMQSender<T> : ISender<T>
        where T : IEntity
    {
        private readonly IInterfaceConnection _connection;
        private readonly IMessageProducer _producer;

        public ActiveMQSender(IActiveMQConnection connection)
        {
            _connection = connection;
            _producer = connection.GetProducer();
        }

        public void Send(T t)
        {
            var msg = ((IActiveMQConnection)_connection).CreateObjectMessage(t);
            _producer.Send(msg);
        }

        public async Task SendAsync(T t)
        {
            await Task.Run(() => Send(t));
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
