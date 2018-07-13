using CarrierPidgeon.Core;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CarrierPidgeon.Component.SqlServer
{
    public class SqlServerSender<TSendType> : IDatabaseSender<TSendType>
        where TSendType : IEntity
    {
        private readonly ISqlServerConnection _connection;
        private readonly ISqlServerCommand _command;

        public SqlServerSender(ISqlServerConnection connection, ISqlServerCommand command)
        {
            _connection = connection;
            _connection.Open();

            _command = command;
        }

        public void Send(TSendType t)
        {
            _command.ClearParameters();

            foreach(var property in t.GetType().GetProperties())
            {
                _command.AddParameter($"@{property.Name}", property.GetValue(t));
            }

            _command.Execute();
        }

        public void Send(string[] parameterNames, TSendType t)
        {
            _command.ClearParameters();

            foreach(var property in t.GetType().GetProperties())
            {
                _command.AddParameter($"@{property.Name}", property.GetValue(t));
            }

            _command.Execute();
        }

        public async Task SendAsync(TSendType t)
        {
            await Task.Run(() => Send(t));       
        }

        public async Task SendAsync(string[] parameterNames, TSendType t)
        {
            await Task.Run(() => Send(parameterNames, t));
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
