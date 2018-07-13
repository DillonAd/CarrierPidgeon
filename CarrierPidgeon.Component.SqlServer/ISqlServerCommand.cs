using System;

namespace CarrierPidgeon.Component.SqlServer
{
    public interface ISqlServerCommand : IDisposable
    {
        void AddParameter(object obj);
        void ClearParameters();
        void Execute();
    }
}