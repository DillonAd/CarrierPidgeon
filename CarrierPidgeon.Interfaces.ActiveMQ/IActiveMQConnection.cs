using Apache.NMS;
using CarrierPidgeon.Core;

namespace CarrierPidgeon.Interfaces.ActiveMQ
{
    public interface IActiveMQConnection : IInterfaceConnection
    {
        IMessageProducer GetProducer();
        IMessageConsumer GetConsumer();
        IObjectMessage CreateObjectMessage(object obj);
    }
}
