namespace CarrierPidgeon.Component.SqlServer
{
    public class SqlServerConnection
    {
        private readonly SqlConnection _connection;
        public SqlConnection Connection => _connection;

        public SqlServerConnection(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }
    }
}