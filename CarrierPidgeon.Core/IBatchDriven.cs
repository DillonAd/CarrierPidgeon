using CarrierPidgeon.Core.BatchDriven;
using System;

namespace CarrierPidgeon.Core
{
    public interface IBatchDriven<TSender, TReceiver> : 
        IInterface<TSender, TReceiver>
        where TSender : ISender<IEntity>
        where TReceiver : IBatchDrivenReceiver
    {
        DateTime NextExecutionTime { get; }
        int IntervalMilliseconds { get; }
        bool IsExecuting { get; }
        bool IsDisposed { get; }

        void Execute();
    }
}
