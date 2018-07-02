using CarrierPidgeon.Core.BatchDriven;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CarrierPidgeon.Component.SqlServer
{
    public class SqlServerSender : IBatchDrivenSender
    {
        private readonly ISqlServerConnection _connection;
        private readonly ISqlServerCommand _command;

        public SqlServerSender(ISqlServerConnection connection, ISqlServerCommand command)
        {
            _connection = connection;
            _connection.Open();

            _command = command;
        }

        public void Push(params object[] parameters)
        {
            _command.ClearParameters();

            foreach(object obj in parameters)
            {
                _command.AddParameter(obj);
            }

            _command.Execute();
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
                _connection.Close();
                _connection.Dispose();
            }
        }
    }
}
