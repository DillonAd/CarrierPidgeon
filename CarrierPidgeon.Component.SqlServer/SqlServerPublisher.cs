﻿using CarrierPidgeon.Core;
using CarrierPidgeon.Core.Events;

namespace CarrierPidgeon.Component.SqlServer
{
    public class SqlServerPublisher : ISender
    {
        private readonly SqlServerConnection _connection;

        public SqlServerPublisher(SqlServerConnection connection)
        {
            _connection = connection;
        }

        public void Send(EventMessage eventMessage)
        {

        }
    }
}
