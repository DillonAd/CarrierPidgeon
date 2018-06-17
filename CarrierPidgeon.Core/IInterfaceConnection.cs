using System;

namespace CarrierPidgeon.Core
{
    public interface IInterfaceConnection : IDisposable
    {
        void Open();
        void Close();
    }
}
