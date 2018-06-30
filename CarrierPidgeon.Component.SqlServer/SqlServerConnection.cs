using System;
using System.Data.SqlClient;

namespace CarrierPidgeon.Component.SqlServer
{
    public sealed class SqlServerConnection : IDisposable
    {
        private readonly SqlConnection _connection;
        public SqlConnection Connection => _connection;

        private readonly SqlCommand _command;
        public SqlCommand Command => _command;

        public SqlServerConnection(string connectionString, string command)
        {
            _connection = new SqlConnection(connectionString);
            _command = new SqlCommand(command, _connection);
        }
        
        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}