using CarrierPidgeon.Core.EventDriven;

namespace CarrierPidgeon.Core
{
    public interface IEventDriven<TSender, TReceiver> : IInterface<TSender, TReceiver>
        where TSender : IEventDrivenSender
        where TReceiver : IEventDrivenReceiver
    {
        bool IsStarted { get; }
        bool IsDisposed { get; }

        void Start();
    }
}
