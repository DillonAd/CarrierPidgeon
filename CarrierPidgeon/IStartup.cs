using CarrierPidgeon.Core;
using CarrierPidgeon.Core.BatchDriven;
using CarrierPidgeon.Core.EventDriven;
using System;
using System.Collections.Generic;

namespace CarrierPidgeon
{
    public interface IStartup : IDisposable
    {
        IEnumerable<IBatchDriven<IBatchDrivenSender, IBatchDrivenReceiver>> BatchDrivenInterfaces { get; }
        IEnumerable<IEventDriven<IEventDrivenSender, IEventDrivenReceiver>> EventDrivenInterfaces { get; }

        void Start();
    }
}
