using System;

namespace CarrierPidgeon.Core
{
    public interface IEventDriven : IDisposable
    {
        bool IsStarted { get; }
        bool IsDisposed { get; }

        void Start();
    }
}
