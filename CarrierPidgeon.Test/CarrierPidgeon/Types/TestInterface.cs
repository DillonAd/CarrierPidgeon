using CarrierPidgeon.Core;
using System;

namespace CarrierPidgeon.Test.CarrierPidgeon.Types
{
    public class TestBatchDrivenInterface : IBatchDriven<ISender, IReceiver>
    {
        public IReceiver Receiver { get; }
        public ISender Sender { get; }

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
