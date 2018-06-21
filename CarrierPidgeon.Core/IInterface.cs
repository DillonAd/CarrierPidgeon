using System;

namespace CarrierPidgeon.Core
{
    public interface IInterface<out TSender, out TReceiver> : IDisposable
        where TSender : IInterfaceComponent
        where TReceiver : IInterfaceComponent
    {
        TReceiver Receiver { get; }
        TSender Sender { get; }
    }
}
