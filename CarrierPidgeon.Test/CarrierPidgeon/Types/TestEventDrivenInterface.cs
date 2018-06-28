using CarrierPidgeon.Core;
using CarrierPidgeon.Core.EventDriven;

namespace CarrierPidgeon.Test.CarrierPidgeon.Types
{
    public class TestEventDrivenInterface : IEventDriven<IEventDrivenSender, IEventDrivenReceiver>
    {
        public IEventDrivenReceiver Receiver { get; }
        public IEventDrivenSender Sender { get; }

        public bool IsStarted { get; private set; }
        public bool IsDisposed { get; private set; }

        public void Start()
        {
            IsStarted = true;
        }

        public void Dispose()
        {
            Receiver.Dispose();
            Sender.Dispose();

            IsStarted = false;
            IsDisposed = true;
        }
    }
}
