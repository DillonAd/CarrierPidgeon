using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CarrierPidgeon.Core;
using CarrierPidgeon.Core.BatchDriven;

namespace CarrierPidgeon.BatchDriven
{
    public sealed class BatchDrivenInterfaceManager : IBatchDrivenInterfaceManager
    {
        public IEnumerable<IBatchDriven<IBatchDrivenSender, IBatchDrivenReceiver>> Interfaces => _interfaces;
        private List<IBatchDriven<IBatchDrivenSender, IBatchDrivenReceiver>> _interfaces { get; set; }

        private bool _isDisposed;
        private Task _runner;

        public BatchDrivenInterfaceManager()
        {
            _interfaces = new List<IBatchDriven<IBatchDrivenSender, IBatchDrivenReceiver>>();
        }

        public void Add(IBatchDriven<IBatchDrivenSender, IBatchDrivenReceiver> batchDrivenInterface)
        {
            _interfaces.Add(batchDrivenInterface);
        }

        public void Start()
        {
            _runner = Task.Run(() => Run());
        }

        private void Run()
        {
            while (!_isDisposed)
            {
                foreach (var @interface in Interfaces)
                {
                    if (DateTime.Now >= @interface.NextExecutionTime && !@interface.IsExecuting)
                    {
                        Task.Run(() => @interface.Execute());
                    }
                }

                Thread.Sleep(1000);
            }
        }

        public void Dispose()
        {
            _isDisposed = true;
            
            while (!_runner.GetAwaiter().IsCompleted) { }

            _interfaces.ForEach(bdi => bdi.Dispose());
        }
    }
}
