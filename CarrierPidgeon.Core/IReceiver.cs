using System;

namespace CarrierPidgeon.Core
{
    public interface IReceiver<TReceiveType> : IDisposable
        where TReceiveType : IEntity { }
}
