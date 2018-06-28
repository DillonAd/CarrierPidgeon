namespace CarrierPidgeon.Core.EventDriven
{
    public interface IEventDrivenReceiver : IReceiver
    {
        event OnMessageReceived MessageReceived;
    }
}
