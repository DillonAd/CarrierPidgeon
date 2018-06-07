using CarrierPidgeon.Core;
using System;
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
            IScheduler batchedInterfaceCollection = new Scheduler();

            foreach(string dllFile in dllFiles)
            {
                assembly = Assembly.LoadFile(dllFile);
                var types = assembly.GetTypes().Where(t => t.IsAssignableFrom(typeof(BatchDrivenInterface))
                    && !t.IsInterface
                    && !t.IsAbstract).ToList();

                foreach(var type in types)
                {
                    if(type.IsAssignableFrom(typeof(BatchDrivenInterface)))
                    {
                        var obj = Activator.CreateInstance(type);
                        ((BatchDrivenInterface)obj).Execute();
                    }
                }
            }
        }
    }
}
