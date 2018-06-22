using System;

namespace CarrierPidgeon.Core
{
    public interface IReceiver : IDisposable
    {
        void OnMessage<T>(T t);
    }
}
