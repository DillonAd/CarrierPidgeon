using CarrierPidgeon.Core.EventDriven;
using System;
using System.Threading.Tasks;

namespace CarrierPidgeon.Core
{
    public interface ISender<in TSendType> : IDisposable 
        where TSendType : IEntity
    {
        void Send(TSendType t);
        Task SendAsync(TSendType t);
    }
}
