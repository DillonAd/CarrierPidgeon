namespace CarrierPidgeon.Core.EventDriven
{
    public interface IEventDrivenReceiver<TReceiveType> : IReceiver<TReceiveType>
        where TReceiveType : IEntity
    {
        event OnMessageReceived MessageReceived;
    }
}
