using CarrierPidgeon.Core;
using CarrierPidgeon.Core.BatchDriven;
using System;

namespace CarrierPidgeon.Test.CarrierPidgeon.Types
{
    public class TestBatchDrivenInterface : IBatchDriven<ISender<IEntity>, IBatchDrivenReceiver<IEntity>>
    {
        public IBatchDrivenReceiver<IEntity> Receiver { get; }
        public ISender<IEntity> Sender { get; }

        public DateTime NextExecutionTime { get; private set; }
        public int IntervalMilliseconds { get; private set; }
        public bool IsExecuting { get; private set; }
        public bool IsDisposed { get; private set; }

        public void Execute()
        {
            IsExecuting = true;

            IsExecuting = false;
        }

        public void Dispose()
        {
            Receiver.Dispose();
            Sender.Dispose();

            IsDisposed = true;
        }
    }
}
