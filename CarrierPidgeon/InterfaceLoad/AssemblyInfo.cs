﻿using CarrierPidgeon.Core;
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
                (type.IsAssignableFrom(typeof(IBatchDriven<ISender, IReceiver>)) ||
                type.IsAssignableFrom(typeof(IEventDriven<ISender, IEventDrivenReceiver>))));
        }
    }
}