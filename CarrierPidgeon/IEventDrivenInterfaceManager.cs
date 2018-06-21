using CarrierPidgeon.Core;
using System;
using System.Collections.Generic;

namespace CarrierPidgeon
{
    public interface IEventDrivenInterfaceManager : IDisposable
    {
        IEnumerable<IEventDriven<IInterfaceComponent, IInterfaceComponent>> Interfaces { get; }

        void Add(IEventDriven<IInterfaceComponent, IInterfaceComponent> @interface);
        void Start();
    }
}
