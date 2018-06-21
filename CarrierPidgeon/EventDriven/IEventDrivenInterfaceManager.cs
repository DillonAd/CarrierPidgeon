using CarrierPidgeon.Core;
using System;
using System.Collections.Generic;

namespace CarrierPidgeon.EventDriven
{
    public interface IEventDrivenInterfaceManager : IDisposable
    {
        IEnumerable<IEventDriven<ISender, IEventDrivenReceiver>> Interfaces { get; }

        void Add(IEventDriven<ISender, IEventDrivenReceiver> @interface);
        void Start();
    }
}
