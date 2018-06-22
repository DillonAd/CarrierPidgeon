using CarrierPidgeon.Core;
using System;
using System.Collections.Generic;

namespace CarrierPidgeon
{
    public interface IStartup : IDisposable
    {
        IEnumerable<IBatchDriven<ISender, IReceiver>> BatchDrivenInterfaces { get; }
        IEnumerable<IEventDriven<ISender, IEventDrivenReceiver>> EventDrivenInterfaces { get; }

        void Start();
    }
}
