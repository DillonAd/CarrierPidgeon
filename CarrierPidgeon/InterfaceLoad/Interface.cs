using CarrierPidgeon.Core;
using System;
using System.Linq;
using System.Reflection;

namespace CarrierPidgeon.InterfaceLoad
{
    public class Interface
    {
        public Type Type { get; }
         

        public Interface(string path)
        {
            var assemblyName = AssemblyName.GetAssemblyName(path);
            var assembly = Assembly.Load(assemblyName);

            Type = assembly.ExportedTypes.FirstOrDefault(t => !t.IsAbstract && 
                !t.IsInterface && 
                (t.IsAssignableFrom(typeof(IBatchDriven<ISender, IReceiver>)) || 
                t.IsAssignableFrom(typeof(IEventDriven<ISender, IEventDrivenReceiver>))));
        }

        public T CreateInstance<T>() =>
            (T)Activator.CreateInstance(Type);
    }
}
