using System;
using System.Collections.Generic;
using System.Text;

namespace CarrierPidgeon.Core
{
    public interface IBatchDriven : IInterfaceComponent
    {
        DateTime LastExecutionTime { get; }
        DateTime NextExecutionTime { get; }
        int IntervalMilliseconds { get; }
        bool IsExecuting { get; }

        void Execute();
    }
}
