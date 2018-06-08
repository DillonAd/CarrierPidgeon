using System;
using System.Threading.Tasks;

namespace CarrierPidgeon.Core
{
    public abstract class EventDrivenInterface
    {
        protected delegate EventHandler OnMessageReceived(EventMessage eventMessage);
        protected event OnMessageReceived MessageReceived;
    }
}
