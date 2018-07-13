using Apache.NMS;
using CarrierPidgeon.Core;
using CarrierPidgeon.Core.EventDriven;
using System;
using System.Threading.Tasks;

namespace CarrierPidgeon.Component.ActiveMQ
{
    public class ActiveMQPublisher : ISender<IEntity>
    {
        private readonly IInterfaceConnection _connection;
        private readonly IMessageProducer _producer;

        public ActiveMQPublisher(IActiveMQConnection connection)
        {
            _connection = connection;
            _producer = connection.GetProducer();
        }

        public void Send(IEntity entity)
        {
            var msg = ((IActiveMQConnection)_connection).CreateObjectMessage(entity);
            _producer.Send(msg);
        }

        public async Task SendAsync(IEntity entity)
        {
            await Task.Run(() => Send(entity));
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
