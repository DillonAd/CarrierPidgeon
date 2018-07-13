using CarrierPidgeon.Core.EventDriven;

namespace CarrierPidgeon.Core
{
    public interface IEventDriven<TSender, TReceiver> : IInterface<TSender, TReceiver>
        where TSender : ISender
        where TReceiver : IEventDrivenReceiver
    {
        bool IsStarted { get; }
        bool IsDisposed { get; }

        void Start();
    }
}
