using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CarrierPidgeon.InterfaceLoad
{
    public class FileSystem : IFileSystem
    {
        public IEnumerable<string> GetDllFiles()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "interfaces");

            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return Directory.GetFiles(path, "*.dll*");
        }
    }
}
