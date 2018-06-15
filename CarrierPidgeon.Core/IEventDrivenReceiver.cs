using CarrierPidgeon.Core.Events;

namespace CarrierPidgeon.Core
{
    public interface IEventDrivenReceiver : IInterfaceComponent, IReceiver
    {
        event OnMessageReceived MessageReceived;
    }
}
