using System;
using System.Data.SqlClient;

namespace CarrierPidgeon.Component.SqlServer
{
    public interface ISqlServerConnection : IDisposable
    {
        void Open();
        void Close();
    }
}