using CarrierPidgeon.Core.Events;

namespace CarrierPidgeon.Core
{
    public interface ISender
    {
        void SendMessage(EventMessage message);
    }
}
