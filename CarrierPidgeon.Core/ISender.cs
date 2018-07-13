using CarrierPidgeon.Core.EventDriven;
using System;
using System.Threading.Tasks;

namespace CarrierPidgeon.Core
{
    public interface ISender<T> : IDisposable 
    {
        void Send(T t);
        Task SendAsync(T t);
    }
}
