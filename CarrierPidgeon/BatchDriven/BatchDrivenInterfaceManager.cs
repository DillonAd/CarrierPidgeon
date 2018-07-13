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
        public IEnumerable<IBatchDriven<ISender<IEntity>, IBatchDrivenReceiver>> Interfaces => _interfaces;
        private List<IBatchDriven<ISender<IEntity>, IBatchDrivenReceiver>> _interfaces { get; set; }

        private bool _isDisposed;
        private Task _runner;

        public BatchDrivenInterfaceManager()
        {
            _interfaces = new List<IBatchDriven<ISender<IEntity>, IBatchDrivenReceiver>>();
        }

        public void Add(IBatchDriven<ISender<IEntity>, IBatchDrivenReceiver> @interface)
        {
            _interfaces.Add(@interface);
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
