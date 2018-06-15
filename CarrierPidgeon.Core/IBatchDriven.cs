using System;
using System.Collections.Generic;
using System.Text;

namespace CarrierPidgeon.Core
{
    public interface IBatchDriven : IInterfaceComponent
    {
        int IntervalMilliseconds { get; }
        
        void Execute();
    }
}
