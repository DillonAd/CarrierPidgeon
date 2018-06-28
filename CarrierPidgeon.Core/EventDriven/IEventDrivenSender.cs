using CarrierPidgeon.Core.EventDriven;
using System;

namespace CarrierPidgeon.Core
{
    public interface IEventDrivenSender : IDisposable
    {
        void SendMessage(EventMessage message);
    }
}
