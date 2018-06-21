using CarrierPidgeon.Core;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CarrierPidgeon
{
    public class Interface
    {
        public Type Type { get; }

        public object Instance => 
            Activator.CreateInstance(Type);
         

        public Interface(string path)
        {
            var assemblyName = AssemblyName.GetAssemblyName(path);
            var assembly = Assembly.Load(assemblyName);

            Type = assembly.ExportedTypes.FirstOrDefault(t => !t.IsAbstract && 
                !t.IsInterface && 
                (t.IsAssignableFrom(typeof(IBatchDriven)) || t.IsAssignableFrom(typeof(IEventDriven))));
        }
    }
}
