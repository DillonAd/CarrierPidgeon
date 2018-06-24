using CarrierPidgeon.Core;
using System;

namespace CarrierPidgeon.Test.CarrierPidgeon.Types
{
    public class TestEventDrivenInterface : IEventDriven<ISender, IEventDrivenReceiver>
    {
        public IEventDrivenReceiver Receiver { get; }
        public ISender Sender { get; }

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
