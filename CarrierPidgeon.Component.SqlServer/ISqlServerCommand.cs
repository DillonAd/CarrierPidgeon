using System;

namespace CarrierPidgeon.Component.SqlServer
{
    public interface ISqlServerCommand : IDisposable
    {
        void AddParameter(string name, object value);
        void ClearParameters();
        void Execute();
    }
}