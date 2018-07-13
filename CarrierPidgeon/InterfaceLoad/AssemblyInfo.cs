using CarrierPidgeon.Core;
using CarrierPidgeon.Core.BatchDriven;
using CarrierPidgeon.Core.EventDriven;
using System;
using System.Linq;
using System.Reflection;

namespace CarrierPidgeon.InterfaceLoad
{
    public class AssemblyInfo : IAssemblyInfo
    {
        public Type GetInterfaceType(string assemblyPath)
        {
            var assemblyName = AssemblyName.GetAssemblyName(assemblyPath);
            return Assembly.Load(assemblyName).ExportedTypes.FirstOrDefault(type =>
                !type.IsAbstract &&
                !type.IsInterface &&
                (type.IsAssignableFrom(typeof(IBatchDriven<ISender<IEntity>, IBatchDrivenReceiver<IEntity>>)) ||
                type.IsAssignableFrom(typeof(IEventDriven<ISender<IEntity>, IEventDrivenReceiver<IEntity>>))));
        }
    }
}
