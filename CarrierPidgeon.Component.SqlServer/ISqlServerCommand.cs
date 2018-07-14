using System;
using System.Data;
using System.Threading.Tasks;

namespace CarrierPidgeon.Component.SqlServer
{
    public interface ISqlServerCommand : IDisposable
    {
        void AddParameter(object value);
        void AddParameter(string name, object value);
        void ClearParameters();
        void Execute();
        IDataReader ExecuteReader();
    }
}