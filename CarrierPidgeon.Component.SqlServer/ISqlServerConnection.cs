using System;

namespace CarrierPidgeon.Component.SqlServer
{
    public interface ISqlServerConnection : IDisposable
    {
        void Open();
        void Close();
    }
}