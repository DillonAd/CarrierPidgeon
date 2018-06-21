using System.Collections.Generic;
using CarrierPidgeon.Core;

namespace CarrierPidgeon.EventDriven
{
    public sealed class EventDrivenInterfaceManager : IEventDrivenInterfaceManager
    {
        public IEnumerable<IEventDriven<ISender, IEventDrivenReceiver>> Interfaces => _interfaces;
        private readonly List<IEventDriven<ISender, IEventDrivenReceiver>> _interfaces;

        public EventDrivenInterfaceManager()
        {
            _interfaces = new List<IEventDriven<ISender, IEventDrivenReceiver>>();
        }

        public void Add(IEventDriven<ISender, IEventDrivenReceiver> @interface) => _interfaces.Add(@interface);

        public void Start() => _interfaces.ForEach(i => i.Start());

        public void Dispose() => _interfaces.ForEach(i => i.Dispose());
    }
}
