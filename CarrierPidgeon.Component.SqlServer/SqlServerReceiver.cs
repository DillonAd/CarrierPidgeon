using CarrierPidgeon.Core.BatchDriven;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CarrierPidgeon.Component.SqlServer
{
    public class SqlServerReceiver : IBatchDrivenReceiver
    {
        public string Command { get; }
        
        private readonly SqlServerConnection _connection;
        private readonly SqlCommand _command;

        public SqlServerReceiver(SqlServerConnection connection, string command)
        {
            Command = command;

            _connection = connection;
            _command = new SqlCommand(_connection.Connection);
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
                _connection.Connection.Dispose();
            }
        }
    }
}