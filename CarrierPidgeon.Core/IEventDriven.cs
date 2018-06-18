using System;

namespace CarrierPidgeon.Core
{
    public interface IEventDriven : IDisposable
    {
        void Start();
    }
}
