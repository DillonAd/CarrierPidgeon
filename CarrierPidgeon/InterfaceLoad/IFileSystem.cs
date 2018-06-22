using System.Collections.Generic;

namespace CarrierPidgeon.InterfaceLoad
{
    public interface IFileSystem
    {
        IEnumerable<string> GetDllFiles();
    }
}
