using System;
using System.Collections.Generic;
using CarrierPidgeon.Core;

namespace CarrierPidgeon
{
    public sealed class BatchDrivenInterfaceManager : IBatchDrivenInterfaceManager
    {
        public IEnumerable<IBatchDriven> Interfaces => _interfaces;
        private List<IBatchDriven> _interfaces { get; set; }

        public BatchDrivenInterfaceManager()
        {
            _interfaces = new List<IBatchDriven>();
        }

        public void Add(IBatchDriven batchDrivenInterface)
        {
            _interfaces.Add(batchDrivenInterface);
        }

        public void Start()
        {
            foreach(var @interface in Interfaces)
            {
                if (DateTime.Now >= @interface.NextExecutionTime && @interface.IsExecuting)
                {
                    @interface.Execute();
                }
            }
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
