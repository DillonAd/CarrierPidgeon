using System.IO;
using System.Reflection;

namespace CarrierPidgeon.Component
{
    public class ComponentManager
    {
        public void LoadComponents()
        {
            var path = Assembly.GetExecutingAssembly().Location;
            var dllFiles = Directory.GetFiles(path, "*.dll");

            Assembly assembly;
            AssemblyName assemblyName;

            foreach (var file in dllFiles)
            {
                assemblyName = AssemblyName.GetAssemblyName(file);
                Assembly.Load(assemblyName);
            }
        }
    }
}
