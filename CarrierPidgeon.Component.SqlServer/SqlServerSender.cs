using CarrierPidgeon.Core.BatchDriven;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CarrierPidgeon.Component.SqlServer
{
    public class SqlServerSender : IBatchDrivenSender
    {
        public string Command { get; }

        private readonly SqlServerConnection _connection;
        private SqlCommand _command;

        public SqlServerSender(SqlServerConnection connection, string command)
        {
            Command = command;

            _connection = connection;
            _command = new SqlCommand(command, _connection.Connection);
        }

        public void Push(params object[] parameters)
        {
            
        }

        public async Task PushAsync(params object[] parameters)
        {
            
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
                _connection.Dispose();
            }
        }
    }
}
