using System;
using System.Data.SqlClient;

namespace CarrierPidgeon.Component.SqlServer
{
    public class SqlServerConnection : ISqlServerConnection
    {
        private readonly SqlConnection _connection;

        public SqlServerConnection(string connectionString, string command)
        {
            _connection = new SqlConnection(connectionString);
        }

        public void Close()
        {
            _connection.Close();
        }

        public void Open()
        {
            _connection.Open();
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _connection.Dispose();
        }
    }
}