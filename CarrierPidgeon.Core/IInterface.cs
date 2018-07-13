using System;

namespace CarrierPidgeon.Core
{
    public interface IInterface<out TSender, out TReceiver> : IDisposable
        where TSender : ISender<IEntity>
        where TReceiver : IReceiver<IEntity>
    {
        TReceiver Receiver { get; }
        TSender Sender { get; }
    }
}
