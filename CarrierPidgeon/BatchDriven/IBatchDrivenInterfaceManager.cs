using CarrierPidgeon.Core;
using CarrierPidgeon.Core.BatchDriven;
using System;
using System.Collections.Generic;

namespace CarrierPidgeon.BatchDriven
{
    public interface IBatchDrivenInterfaceManager : IDisposable
    {
        IEnumerable<IBatchDriven<IBatchDrivenSender, IBatchDrivenReceiver>> Interfaces { get; }

        void Add(IBatchDriven<IBatchDrivenSender, IBatchDrivenReceiver> batchDrivenInterface);
        void Start();
    }
}
