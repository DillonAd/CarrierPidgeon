using System.Collections.Generic;
using CarrierPidgeon.Core;

namespace CarrierPidgeon
{
    public class EventDrivenInterfaceManager : IEventDrivenInterfaceManager
    {
        public IEnumerable<IEventDriven> Interfaces => _interfaces;
        private readonly List<IEventDriven> _interfaces;

        public void Add(IEventDriven @interface)
        {
            _interfaces.Add(@interface);
        }

        public void Start()
        {
            foreach(var @interface in _interfaces)
            {
                @interface.Start();
            }
        }

        public void Dispose()
        {
            foreach (var @interface in _interfaces)
            {
                @interface.Dispose();
            }
        }
    }
}
