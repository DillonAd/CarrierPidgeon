using System;
using System.Threading.Tasks;

namespace CarrierPidgeon.Contracts
{
    public abstract class EventDriven<T> : IExecutable
    {
        protected delegate EventHandler OnMessageReceived<T>(T t);
        protected event OnMessageReceived<T> MessageReceived;

        protected EventDriven()
        {
            
        }

        public abstract void Execute();
        public async virtual Task ExecuteAsync() { }
    }
}
