using CarrierPidgeon.Core;
using CarrierPidgeon.Core.BatchDriven;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CarrierPidgeon.Component.SqlServer
{
    public class SqlServerReceiver<TReceiveType> : DatabaseMapper<TReceiveType>, IBatchDrivenReceiver<TReceiveType>
        where TReceiveType : IEntity, new()
    {
        private readonly ISqlServerConnection _connection;
        private readonly ISqlServerCommand _command;

        public SqlServerReceiver(ISqlServerConnection connection, ISqlServerCommand command)
        {
            _connection = connection;
            _command = command;
        }

        public IEnumerable<TReceiveType> Pull(params object[] parameters)
        {
            foreach(var parameter in parameters)
            {
               _command.AddParameter(parameter);
            }

            var r = _command.ExecuteReader();

            var resultTable = new DataTable();
            resultTable.Load(r);

            return Map(resultTable);
        }

        public async Task<IEnumerable<TReceiveType>> PullAsync(params object[] parameters)
        {
            return await Task.Run(() => { return Pull(parameters); });
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
                _command.Dispose();
                _connection.Dispose();
            }
        }
    }
}