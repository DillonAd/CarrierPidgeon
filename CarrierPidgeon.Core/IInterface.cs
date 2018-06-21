namespace CarrierPidgeon.Core
{
    public interface IInterface<out TSender, out TReceiver>
        where TSender : IInterfaceComponent
        where TReceiver : IInterfaceComponent
    {
        TReceiver Receiver { get; }
        TSender Sender { get; }
    }
}
