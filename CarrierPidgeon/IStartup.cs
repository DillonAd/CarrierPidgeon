using System;

namespace CarrierPidgeon
{
    public interface IStartup : IDisposable
    {
        void Start();
    }
}
