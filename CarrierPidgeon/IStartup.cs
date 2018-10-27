using CarrierPidgeon.Core;
using CarrierPidgeon.Core.BatchDriven;
using CarrierPidgeon.Core.EventDriven;
using System;
using System.Collections.Generic;

namespace CarrierPidgeon
{
    public interface IStartup
    {
        IEnumerable<IBatchDriven<ISender<IEntity>, IBatchDrivenReceiver<IEntity>>> BatchDrivenInterfaces { get; }
        IEnumerable<IEventDriven<ISender<IEntity>, IEventDrivenReceiver<IEntity>>> EventDrivenInterfaces { get; }
    }
}
