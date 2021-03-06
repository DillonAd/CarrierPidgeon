﻿using CarrierPidgeon.Core;
using CarrierPidgeon.Core.EventDriven;
using System;
using System.Collections.Generic;

namespace CarrierPidgeon.EventDriven
{
    public interface IEventDrivenInterfaceManager : IDisposable
    {
        IEnumerable<IEventDriven<ISender<IEntity>, IEventDrivenReceiver<IEntity>>> Interfaces { get; }

        void Add(IEventDriven<ISender<IEntity>, IEventDrivenReceiver<IEntity>> @interface);
        void Start();
    }
}
