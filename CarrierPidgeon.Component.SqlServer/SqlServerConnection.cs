using System;
using System.Data.SqlClient;

namespace CarrierPidgeon.Component.SqlServer
{
    public sealed class SqlServerConnection : IDisposable
    {
        private readonly SqlConnection _connection;
        public SqlConnection Connection => _connection;

        public SqlServerConnection(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}