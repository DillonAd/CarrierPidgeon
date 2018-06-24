using CarrierPidgeon.Core;
using System;
using System.Linq;
using System.Reflection;

namespace CarrierPidgeon.InterfaceLoad
{
    public class Interface
    {
        public Type Type { get; }

        public Interface(Type type)
        {
            Type = type;
                   
            if(type == null ||
                !typeof(IBatchDriven<ISender, IReceiver>).IsAssignableFrom(type))
            {
                throw new InvalidCastException("Invalid Interface Type");
            }
        }

        public T CreateInstance<T>() =>
            (T)Activator.CreateInstance(Type);
    }
}
