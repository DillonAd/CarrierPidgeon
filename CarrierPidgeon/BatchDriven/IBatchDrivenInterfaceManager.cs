﻿using CarrierPidgeon.Core;
using CarrierPidgeon.Core.BatchDriven;
using System;
using System.Collections.Generic;

namespace CarrierPidgeon.BatchDriven
{
    public interface IBatchDrivenInterfaceManager : IDisposable
    {
        IEnumerable<IBatchDriven<ISender<IEntity>, IBatchDrivenReceiver<IEntity>>> Interfaces { get; }

        void Add(IBatchDriven<ISender<IEntity>, IBatchDrivenReceiver<IEntity>> @interface);
        void Start();
    }
}
