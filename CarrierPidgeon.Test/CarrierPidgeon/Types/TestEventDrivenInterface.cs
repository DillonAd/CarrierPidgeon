using CarrierPidgeon.Core;
using CarrierPidgeon.Core.EventDriven;

namespace CarrierPidgeon.Test.CarrierPidgeon.Types
{
    public class TestEventDrivenInterface : IEventDriven<ISender<IEntity>, IEventDrivenReceiver<IEntity>>
    {
        public IEventDrivenReceiver<IEntity> Receiver { get; }
        public ISender<IEntity> Sender { get; }

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
