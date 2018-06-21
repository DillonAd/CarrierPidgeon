using CarrierPidgeon.Core;
using System;
using System.Collections.Generic;

namespace CarrierPidgeon
{
    public interface IBatchDrivenInterfaceManager : IDisposable
    {
        IEnumerable<IBatchDriven<IInterfaceComponent, IInterfaceComponent>> Interfaces { get; }

        void Add(IBatchDriven<IInterfaceComponent, IInterfaceComponent> batchDrivenInterface);
        void Start();
    }
}
