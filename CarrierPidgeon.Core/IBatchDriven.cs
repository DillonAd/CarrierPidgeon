using System;
using System.Collections.Generic;
using System.Text;

namespace CarrierPidgeon.Core
{
    public interface IBatchDriven<TSender, TReceiver> : IInterface<TSender, TReceiver>
        where TSender : IInterfaceComponent
        where TReceiver : IInterfaceComponent
    {
        DateTime NextExecutionTime { get; }
        int IntervalMilliseconds { get; }
        bool IsExecuting { get; }
        bool IsDisposed { get; }

        void Execute();
    }
}
