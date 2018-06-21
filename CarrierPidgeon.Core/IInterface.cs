using System;

namespace CarrierPidgeon.Core
{
    public interface IInterface<out TSender, out TReceiver> : IDisposable
        where TSender : ISender
        where TReceiver : IReceiver
    {
        TReceiver Receiver { get; }
        TSender Sender { get; }
    }
}
