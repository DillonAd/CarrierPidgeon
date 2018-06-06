using System;
using System.Collections.Generic;
using System.Text;

namespace CarrierPidgeon.Core
{
    public abstract class BatchDrivenInterface
    {
        protected int IntervalMilliseconds { get; }

        protected BatchDrivenInterface(int intervalMillisonds)
        {
            IntervalMilliseconds = intervalMillisonds;
        }

        public abstract void Execute();
    }
}
