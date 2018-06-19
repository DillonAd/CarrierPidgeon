using System;
using System.Collections.Generic;
using System.Text;

namespace CarrierPidgeon.Core
{
    public interface IBatchDriven : IInterfaceComponent
    {
        DateTime NextExecutionTime { get; }
        int IntervalMilliseconds { get; }
        bool IsExecuting { get; }
        bool IsDisposed { get; }

        void Execute();
    }
}
