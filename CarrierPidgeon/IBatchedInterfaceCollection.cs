using CarrierPidgeon.Core;
using System;
using System.Collections.Generic;

namespace CarrierPidgeon
{
    public interface IBatchedInterfaceCollection : IDisposable
    {
        IEnumerable<BatchDrivenInterface> Interfaces { get; }

        void Add(BatchDrivenInterface batchDrivenInterface);
        void Start();
    }
}
