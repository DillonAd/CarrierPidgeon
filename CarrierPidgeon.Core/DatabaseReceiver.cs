using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace CarrierPidgeon.Core
{
    public abstract class DatabaseReceiver<TEntity>
        where TEntity : IEntity
    {
        private readonly IEnumerable<PropertyInfo> _properties;

        protected DatabaseReceiver()
        {
            _properties = typeof(TEntity).GetProperties();
        }

        protected virtual IEnumerable<TEntity> Map(DataTable dataTable)
        {
            DataRow row;
            object value;
            TEntity entity = (TEntity)Activator.CreateInstance(typeof(TEntity));

            for(int i = 0; i < dataTable.Rows.Count; i++)
            {
                row = dataTable.Rows[i];

                foreach(var property in _properties)
                {
                    value = row[property.Name];
                    property.SetValue(entity, value);
                }

                yield return entity;
            }
        }
    }
}