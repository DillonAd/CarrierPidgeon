using System.Collections.Generic;
using CarrierPidgeon.Core;

namespace CarrierPidgeon
{
    public class BatchedInterfaceCollection : IBatchedInterfaceCollection
    {
        public IEnumerable<BatchDrivenInterface> Interfaces => _interfaces;
        private List<BatchDrivenInterface> _interfaces { get; set; }

        public void Add(BatchDrivenInterface batchDrivenInterface)
        {
            _interfaces.Add(batchDrivenInterface);
        }

        public void Start()
        {
            foreach(var @interface in Interfaces)
            {
                @interface.Execute();
            }
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
