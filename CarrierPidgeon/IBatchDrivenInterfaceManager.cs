using CarrierPidgeon.Core;
using System;
using System.Collections.Generic;

namespace CarrierPidgeon
{
    public interface IBatchDrivenInterfaceManager : IDisposable
    {
        IEnumerable<IBatchDriven> Interfaces { get; }

        void Add(IBatchDriven batchDrivenInterface);
        void Start();
    }
}
