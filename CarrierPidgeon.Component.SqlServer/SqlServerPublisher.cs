using CarrierPidgeon.Core;
using CarrierPidgeon.Core.Events;
using System;

namespace CarrierPidgeon.Component.SqlServer
{
    public class SqlServerPublisher : ISender
    {
        private readonly SqlServerConnection _connection;

        public SqlServerPublisher(SqlServerConnection connection)
        {
            _connection = connection;
        }

        public void SendMessage(EventMessage message)
        {
            
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
