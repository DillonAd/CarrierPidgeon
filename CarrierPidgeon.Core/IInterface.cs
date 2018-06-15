namespace CarrierPidgeon.Core
{
    public interface IInterface<TReceiver, TSender>
        where TReceiver : IInterfaceComponent
        where TSender : IInterfaceComponent
    {
        TReceiver Receiver { get; }
        TSender Sender { get; }
    }
}
