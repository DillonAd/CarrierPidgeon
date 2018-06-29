using CarrierPidgeon.Core.BatchDriven;
using System;
using System.Threading.Tasks;

namespace CarrierPidgeon.Component.SqlServer
{
    public class SqlServerPublisher : IBatchDrivenSender
    {
        public string Command { get; }

        private readonly SqlServerConnection _connection;

        public SqlServerPublisher(SqlServerConnection connection)
        {
            _connection = connection;
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
            _connection.Dispose();
        }
    }
}
