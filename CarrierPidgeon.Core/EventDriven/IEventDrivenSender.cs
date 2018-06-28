using CarrierPidgeon.Core.EventDriven;
using System;

namespace CarrierPidgeon.Core
{
    public interface IEventDrivenSender : ISender, IDisposable
    {
        void SendMessage(EventMessage message);
    }
}
