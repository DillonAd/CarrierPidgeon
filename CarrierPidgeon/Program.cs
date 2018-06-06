using CarrierPidgeon.Core;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CarrierPidgeon
{
    class Program
    {
        static void Main(string[] args)
        {
            string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string[] dllFiles = Directory.GetFiles(assemblyFolder, "*.dll");

            Assembly assembly;

            foreach(string dllFile in dllFiles)
            {
                assembly = Assembly.LoadFile(dllFile);
                var types = assembly.GetTypes().Where(t => t.IsAssignableFrom(typeof(BatchDrivenInterface)) 
                    && !t.IsInterface
                    && !t.IsAbstract);
            }
        }
    }
}
