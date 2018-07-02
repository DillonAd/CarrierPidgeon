using System;
using System.Data.SqlClient;

namespace CarrierPidgeon.Component.SqlServer
{
    public class SqlServerCommand : ISqlServerCommand
    {
        private readonly SqlCommand _command;
        public SqlCommand Command => _command;

        public SqlServerCommand(string command, SqlConnection connection)
        {
            _command = new SqlCommand(command, connection);
        }

        public void AddParameter(object obj)
        {
            _command.Parameters.Add(obj);
        }

        public void ClearParameters()
        {
            _command.Parameters.Clear();
        }

        public void Execute()
        {
            _command.ExecuteNonQuery();
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _command.Dispose();
        }
    }
}