using System.Collections.Generic;
using CarrierPidgeon.Core;
using CarrierPidgeon.Core.EventDriven;

namespace CarrierPidgeon.EventDriven
{
    public sealed class EventDrivenInterfaceManager : IEventDrivenInterfaceManager
    {
        public IEnumerable<IEventDriven<IEventDrivenSender, IEventDrivenReceiver>> Interfaces => _interfaces;

        private readonly List<IEventDriven<IEventDrivenSender, IEventDrivenReceiver>> _interfaces;

        public EventDrivenInterfaceManager()
        {
            _interfaces = new List<IEventDriven<IEventDrivenSender, IEventDrivenReceiver>>();
        }

        public void Add(IEventDriven<IEventDrivenSender, IEventDrivenReceiver> @interface) => _interfaces.Add(@interface);

        public void Start() => _interfaces.ForEach(i => i.Start());

        public void Dispose() => _interfaces.ForEach(i => i.Dispose());
    }
}
