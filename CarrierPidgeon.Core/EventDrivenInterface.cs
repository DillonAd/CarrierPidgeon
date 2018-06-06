using System;
using System.Threading.Tasks;

namespace CarrierPidgeon.Core
{
    public abstract class EventDrivenInterface<T>
    {
        protected delegate EventHandler OnMessageReceived<T>(T t);
        protected event OnMessageReceived<T> MessageReceived;
    }
}
