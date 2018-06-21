using CarrierPidgeon.Core.Events;

namespace CarrierPidgeon.Core
{
    public interface IEventDrivenReceiver : IReceiver
    {
        event OnMessageReceived MessageReceived;
    }
}
