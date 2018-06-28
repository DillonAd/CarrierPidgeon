using System;

namespace CarrierPidgeon.InterfaceLoad
{
    public interface IAssemblyInfo
    {
        Type GetInterfaceType(string assemblyPath);
    }
}
