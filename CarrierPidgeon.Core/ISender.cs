using CarrierPidgeon.Core.Events;
using System;

namespace CarrierPidgeon.Core
{
    public interface ISender : IDisposable
    {
        void SendMessage(EventMessage message);
    }
}
