namespace CarrierPidgeon.Core
{
    public interface IInterface<out TReceiver, out TSender>
        where TReceiver : IInterfaceComponent
        where TSender : IInterfaceComponent
    {
        TReceiver Receiver { get; }
        TSender Sender { get; }
    }
}
