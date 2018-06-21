using System;

namespace CarrierPidgeon.Core
{
    public interface IEventDriven<TSender, TReceiver> : IInterface<TSender, TReceiver>
        where TSender : IInterfaceComponent
        where TReceiver : IInterfaceComponent
    {
        bool IsStarted { get; }
        bool IsDisposed { get; }

        void Start();
    }
}
