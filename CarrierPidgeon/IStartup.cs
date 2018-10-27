using CarrierPidgeon.Core;
using CarrierPidgeon.Core.BatchDriven;
using CarrierPidgeon.Core.EventDriven;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;

namespace CarrierPidgeon
{
    public interface IStartup : IHostedService
    {
        IEnumerable<IBatchDriven<ISender<IEntity>, IBatchDrivenReceiver<IEntity>>> BatchDrivenInterfaces { get; }
        IEnumerable<IEventDriven<ISender<IEntity>, IEventDrivenReceiver<IEntity>>> EventDrivenInterfaces { get; }
    }
}
