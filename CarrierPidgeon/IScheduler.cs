using CarrierPidgeon.Core;
using System;
using System.Collections.Generic;

namespace CarrierPidgeon
{
    public interface IScheduler : IDisposable
    {
        IEnumerable<BatchDrivenInterface> Interfaces { get; }

        void Add(BatchDrivenInterface batchDrivenInterface);
        void Start();
    }
}
