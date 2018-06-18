using CarrierPidgeon.Core;
using System;
using System.Collections.Generic;

namespace CarrierPidgeon
{
    public interface IEventDrivenInterfaceManager : IDisposable
    {
        IEnumerable<IEventDriven> Interfaces { get; }

        void Add(IEventDriven @interface);
        void Start();
    }
}
