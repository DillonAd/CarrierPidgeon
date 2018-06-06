using System;
using System.Collections.Generic;
using System.Text;

namespace CarrierPidgeon.Contracts
{
    public interface IBatchDrivable : IExecutable
    {
        int Interval { get; }
    }
}
