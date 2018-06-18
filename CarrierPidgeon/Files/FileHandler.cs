using System.IO;
using System.Reflection;

namespace CarrierPidgeon.Files
{
    public class FileHandler : IFileHandler
    {
        public string[] GetDllFiles()
        {
            string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string[] dllFiles = Directory.GetFiles(assemblyFolder, "*.dll");

            return dllFiles;
        }
    }
}
