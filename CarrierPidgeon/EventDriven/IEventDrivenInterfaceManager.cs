using CarrierPidgeon.Core;
using CarrierPidgeon.Core.EventDriven;
using System;
using System.Collections.Generic;

namespace CarrierPidgeon.EventDriven
{
    public interface IEventDrivenInterfaceManager : IDisposable
    {
        IEnumerable<IEventDriven<IEventDrivenSender, IEventDrivenReceiver>> Interfaces { get; }

        void Add(IEventDriven<IEventDrivenSender, IEventDrivenReceiver> @interface);
        void Start();
    }
}
