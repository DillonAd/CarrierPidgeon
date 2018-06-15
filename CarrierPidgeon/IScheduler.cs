using CarrierPidgeon.Core;
using System;
using System.Collections.Generic;

namespace CarrierPidgeon
{
    public interface IScheduler : IDisposable
    {
        IEnumerable<IBatchDriven> Interfaces { get; }

        void Add(IBatchDriven batchDrivenInterface);
        void Start();
    }
}
