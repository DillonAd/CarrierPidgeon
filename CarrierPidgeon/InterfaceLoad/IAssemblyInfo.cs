using System;
using System.Reflection;

namespace CarrierPidgeon.InterfaceLoad
{
    public interface IAssemblyInfo
    {
        Type GetInterfaceType(string assemblyPath);
    }
}
