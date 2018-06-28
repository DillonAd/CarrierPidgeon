using CarrierPidgeon.Core;
using CarrierPidgeon.Core.BatchDriven;
using CarrierPidgeon.Core.EventDriven;
using System;

namespace CarrierPidgeon.InterfaceLoad
{
    public class Interface
    {
        public Type Type { get; }

        public Interface(Type type)
        {
            Type = type;
                   
            if(type == null ||
                (!typeof(IBatchDriven<IBatchDrivenSender, IBatchDrivenReceiver>).IsAssignableFrom(type) &&
                !typeof(IEventDriven<IEventDrivenSender, IEventDrivenReceiver>).IsAssignableFrom(type)))
            {
                throw new InvalidCastException("Invalid Interface Type");
            }
        }

        public T CreateInstance<T>() =>
            (T)Activator.CreateInstance(Type);
    }
}
