using CarrierPidgeon.Core;
using CarrierPidgeon.Core.BatchDriven;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CarrierPidgeon.Component.SqlServer
{
    public class SqlServerReceiver<TReceiveType> : IBatchDrivenReceiver<TReceiveType>
        where TReceiveType : IEntity
    {
        private readonly ISqlServerConnection _connection;
        private readonly ISqlServerCommand _command;

        public SqlServerReceiver(ISqlServerConnection connection, ISqlServerCommand command)
        {
            _connection = connection;
            _command = command;
        }

        public DataTable Pull(params object[] parameters)
        {
            throw new NotImplementedException();   
        }

        public Task<DataTable> PullAsync(params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                _command.Dispose();
                _connection.Dispose();
            }
        }
    }
}