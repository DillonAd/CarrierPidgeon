using System;
using System.Collections.Generic;
using System.Text;

namespace CarrierPidgeon.Core
{
    public class InterfaceComponentAttribute : Attribute
    {
        public string Name { get; }
        public string Version { get; set; }

        public InterfaceComponentAttribute(string name, string version)
        {
            Name = name;
            Version = version;
        }
    }
}
