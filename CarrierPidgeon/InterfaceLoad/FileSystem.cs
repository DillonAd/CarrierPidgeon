using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CarrierPidgeon.InterfaceLoad
{
    public class FileSystem : IFileSystem
    {
        public IEnumerable<string> GetDllFiles()
        {
            var path = Directory.GetCurrentDirectory();
            return Directory.GetFiles(path, "*.dll*");
        }
    }
}
