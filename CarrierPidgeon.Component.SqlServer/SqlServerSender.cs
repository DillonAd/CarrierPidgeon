using CarrierPidgeon.Core.BatchDriven;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CarrierPidgeon.Component.SqlServer
{
    public class SqlServerSender : IBatchDrivenSender
    {
        public string Command => _connection.Command.CommandText;

        private readonly SqlServerConnection _connection;

        public SqlServerSender(SqlServerConnection connection)
        {
            _connection = connection;
        }

        public void Push(params object[] parameters)
        {
            _connection.Command.Parameters.Clear();

            foreach(object obj in parameters)
            {
                _connection.Command.Parameters.Add(obj);
            }

            _connection.Command.ExecuteNonQuery();
        }

        public async Task PushAsync(params object[] parameters)
        {
            await Task.Run(() => Push(parameters));       
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
