using System.Collections.Generic;
using CarrierPidgeon.Core;

namespace CarrierPidgeon
{
    public sealed class EventDrivenInterfaceManager : IEventDrivenInterfaceManager
    {
        public IEnumerable<IEventDriven<IInterfaceComponent, IInterfaceComponent>> Interfaces => _interfaces;
        private readonly List<IEventDriven<IInterfaceComponent, IInterfaceComponent>> _interfaces;

        public EventDrivenInterfaceManager()
        {
            _interfaces = new List<IEventDriven<IInterfaceComponent, IInterfaceComponent>>();
        }

        public void Add(IEventDriven<IInterfaceComponent, IInterfaceComponent> @interface) => _interfaces.Add(@interface);

        public void Start() => _interfaces.ForEach(i => i.Start());

        public void Dispose() => _interfaces.ForEach(i => i.Dispose());
    }
}
