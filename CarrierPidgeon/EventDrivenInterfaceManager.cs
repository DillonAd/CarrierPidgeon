using System.Collections.Generic;
using CarrierPidgeon.Core;

namespace CarrierPidgeon
{
    public sealed class EventDrivenInterfaceManager : IEventDrivenInterfaceManager
    {
        public IEnumerable<IEventDriven> Interfaces => _interfaces;
        private readonly List<IEventDriven> _interfaces;

        public EventDrivenInterfaceManager()
        {
            _interfaces = new List<IEventDriven>();
        }

        public void Add(IEventDriven @interface) => _interfaces.Add(@interface);

        public void Start() => _interfaces.ForEach(i => i.Start());

        public void Dispose() => _interfaces.ForEach(i => i.Dispose());
    }
}
