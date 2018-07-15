using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CarrierPidgeon.Core
{
    public abstract class DatabaseMapper<TEntity>
        where TEntity : new()
    {
        private List<string> _fields;
        private IEnumerable<string> _properties;

        public DatabaseMapper()
        {
            _properties = typeof(TEntity).GetProperties().Select(e => e.Name);
        }


        protected virtual IEnumerable<TEntity> Map(DataTable dataTable)
        {
            DataRow row;
            object value;
            TEntity entity = new TEntity();

            for(int i = 0; i < dataTable.Rows.Count; i++)
            {
                row = dataTable.Rows[i];

                foreach(var property in typeof(TEntity).GetProperties())
                {
                    value = row[property.Name];
                    property.SetValue(entity, value);
                }

                yield return entity;
            }
        }
    }
}