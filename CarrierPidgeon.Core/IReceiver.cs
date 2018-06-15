namespace CarrierPidgeon.Core
{
    public interface IReceiver
    {
        void OnMessage<T>(T t);
    }
}
