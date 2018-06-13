namespace CarrierPidgeon.Core
{
    public interface Interface<TReceiver, TSender>
        where TReceiver : IInterfaceMember
        where TSender : IInterfaceMember
    {
        TReceiver Receiver { get; }
        TSender Sender { get; }
    }
}
