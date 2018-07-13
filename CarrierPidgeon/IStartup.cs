using CarrierPidgeon.Core;
using CarrierPidgeon.Core.BatchDriven;
using CarrierPidgeon.Core.EventDriven;
using System;
using System.Collections.Generic;

namespace CarrierPidgeon
{
    public interface IStartup : IDisposable
    {
        IEnumerable<IBatchDriven<ISender<IEntity>, IBatchDrivenReceiver>> BatchDrivenInterfaces { get; }
        IEnumerable<IEventDriven<ISender<IEntity>, IEventDrivenReceiver>> EventDrivenInterfaces { get; }

        void Start();
    }
}
