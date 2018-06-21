using CarrierPidgeon.Core;
using System;
using System.Collections.Generic;

namespace CarrierPidgeon
{
    public interface IBatchDrivenInterfaceManager : IDisposable
    {
        IEnumerable<IBatchDriven<ISender, IReceiver>> Interfaces { get; }

        void Add(IBatchDriven<ISender, IReceiver> batchDrivenInterface);
        void Start();
    }
}
