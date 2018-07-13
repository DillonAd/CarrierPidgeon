using CarrierPidgeon.Core;
using CarrierPidgeon.Core.BatchDriven;
using System;
using System.Collections.Generic;

namespace CarrierPidgeon.BatchDriven
{
    public interface IBatchDrivenInterfaceManager : IDisposable
    {
        IEnumerable<IBatchDriven<ISender, IBatchDrivenReceiver>> Interfaces { get; }

        void Add(IBatchDriven<ISender, IBatchDrivenReceiver> @interface);
        void Start();
    }
}
