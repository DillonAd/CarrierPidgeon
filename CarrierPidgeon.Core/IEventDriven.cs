using CarrierPidgeon.Core.EventDriven;

namespace CarrierPidgeon.Core
{
    public interface IEventDriven<TSender, TReceiver> : 
        IInterface<TSender, TReceiver>
        where TSender : ISender<IEntity>
        where TReceiver : IEventDrivenReceiver
    {
        bool IsStarted { get; }
        bool IsDisposed { get; }

        void Start();
    }
}
